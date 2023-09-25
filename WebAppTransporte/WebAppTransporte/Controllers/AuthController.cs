using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebAppTransporte.Helpers;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;
using WebAppTransporte.Models.Usuarios.MSN;

namespace WebAppTransporte.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration configuration;
		private readonly IUsuariosServicios iUsuariosServicios;

		private readonly string AuthCodeEndPoint;
		private readonly string TokenEndPoint;
		private readonly string ClientId;
		private readonly string Secret;
		private readonly string Scope;
		private readonly string RedirectURI;
		private readonly string API_EndPoint;
		public AuthController(
			IConfiguration configuration,
			IUsuariosServicios iUsuariosServicios
			)
		{
			this.configuration = configuration;
			this.iUsuariosServicios = iUsuariosServicios;
			this.AuthCodeEndPoint = configuration["OAuth:AuthCodeEndPoint"] ?? "";
			this.TokenEndPoint = configuration["OAuth:TokenEndPoint"] ?? "";
			this.ClientId = configuration["OAuth:ClientId"] ?? "";
			this.Secret = configuration["OAuth:Secret"] ?? "";
			this.Scope = configuration["OAuth:Scope"] ?? "";
			this.RedirectURI = configuration["OAuth:RedirectURI"] ?? "";
			this.API_EndPoint = configuration["OAuth:API_EndPoint"] ?? "";
		}
		[HttpGet("getcode")]
		public IActionResult GetCode()
		{
			string URL = $"{this.AuthCodeEndPoint}?" +
				$"response_type=code&" +
				$"client_id={ClientId}&" +
				$"Redirect_uri={RedirectURI}&" +
				$"scope={Scope}&" +
				$"state=1234567890";
			return Redirect(URL);
		}

		[HttpPost("")]
		public async Task<IActionResult> Autenticar([FromBody] loginRequest modelo)
		{
			string grant_type = "authorization_code";

			Dictionary<string, string> BodyData = new Dictionary<string, string>()
			{
				{ "grant_type", grant_type },
				{ "code", modelo.code },
				{ "Redirect_uri", this.RedirectURI },
				{ "client_id", this.ClientId },
				{ "client_secret", this.Secret },
				{ "scope", this.Scope }
			};
			HttpClient client = new HttpClient();
			var body = new FormUrlEncodedContent(BodyData);
			var response = await client.PostAsync(TokenEndPoint, body);
			var status = $"{(int)response.StatusCode} {response.ReasonPhrase}";

			var jsonCOntent = await response.Content.ReadFromJsonAsync<JsonElement>();

			var prettyJson = JsonSerializer.Serialize(jsonCOntent, new JsonSerializerOptions { WriteIndented = true });

			var accesToken = JsonDocument.Parse(prettyJson).RootElement.GetProperty("access_token").GetString();
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesToken);

			var response1 = await httpClient.GetAsync(API_EndPoint);
			dynamic ojJSON = new ExpandoObject();
			ojJSON.respuesta = "";
			ojJSON.autenticado = false;
			if (response1.IsSuccessStatusCode)
			{
				var jsUsuarioMSN = Newtonsoft.Json.JsonConvert.DeserializeObject< UsuarioMSN>(await response1.Content.ReadAsStringAsync());

				status = $"{(int)response1.StatusCode} {response1.ReasonPhrase}";
				if (!string.IsNullOrEmpty(jsUsuarioMSN?.id))
				{
					var usuario = await iUsuariosServicios.ConsultarPorCodigoExterno(jsUsuarioMSN.id);
					var respuesta = generateJwtToken(usuario);
					ojJSON.respuesta = respuesta;
					ojJSON.autenticado = true;
					return Ok(ojJSON);
				}
				else return Ok(ojJSON);
			}
			else
			{
				return Ok(ojJSON);
			}
		}

		private string generateJwtToken(Usuarios user)
		{
			// generate token that is valid for 7 days
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"] ?? "");
			var lstClaims = new List<Claim>();
			lstClaims.Add(new Claim("id", user.idUsuario.ToString()));
			lstClaims.Add(new Claim("idEmpresa", "4"));
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(lstClaims),
				Expires = DateTime.UtcNow.AddDays(7),
				Issuer = configuration["Jwt:Issuer"] ?? "",
				Audience = configuration["Jwt:Audience"] ?? "",
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}



		[HttpGet("login-callback")] 
		public async Task<IActionResult> GetCallback([FromQuery] string code, string state) 
		{
			string grant_type = "authorization_code";

			Dictionary<string,string> BodyData = new Dictionary<string, string>()
			{
				{ "grant_type", grant_type },
				{ "code", code },
				{ "Redirect_uri", this.RedirectURI },
				{ "client_id", this.ClientId },
				{ "client_secret", this.Secret },
				{ "scope", this.Scope }
			};
			HttpClient client = new HttpClient();
			var body = new FormUrlEncodedContent(BodyData);
			var response = await client.PostAsync(TokenEndPoint, body);
			var status = $"{(int)response.StatusCode} {response.ReasonPhrase}" ;

			var jsonCOntent = await response.Content.ReadFromJsonAsync<JsonElement>();

			var prettyJson = JsonSerializer.Serialize(jsonCOntent, new JsonSerializerOptions { WriteIndented = true });

			var accesToken = JsonDocument.Parse(prettyJson).RootElement.GetProperty("access_token").GetString();
			var jwtToken = new JwtSecurityToken(accesToken);
			var ss = jwtToken.Subject;
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accesToken);

			var response1 = await httpClient.GetAsync(API_EndPoint);
			if (response1.IsSuccessStatusCode)
			{
				var resultado = await response1.Content.ReadAsStringAsync();

				var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(resultado) as Newtonsoft.Json.Linq.JObject;
				var js = Newtonsoft.Json.JsonConvert.DeserializeObject(resultado);
				var jsonRes = JsonSerializer.Deserialize<JsonElement>(resultado);
				var js2 = JsonSerializer.Deserialize<JsonElement>(jsonRes,
						new JsonSerializerOptions
						{
							WriteIndented = true,
							Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping

						}
					);
				status = $"{(int)response1.StatusCode} {response1.ReasonPhrase}";
				return Ok($"{status + Environment.NewLine}{js2 + Environment.NewLine}{response1.IsSuccessStatusCode}");
			}
			else
			{
				return Ok($"{status + Environment.NewLine}{prettyJson + Environment.NewLine}{response.IsSuccessStatusCode}");
			}
			
		}
	}
}
