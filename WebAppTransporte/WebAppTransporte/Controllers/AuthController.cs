using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebAppTransporte.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration configuration;

		private readonly string AuthCodeEndPoint;
		private readonly string TokenEndPoint;
		private readonly string ClientId;
		private readonly string Secret;
		private readonly string Scope;
		private readonly string RedirectURI;
		private readonly string API_EndPoint;
		public AuthController(IConfiguration configuration)
		{
			this.configuration = configuration;
			this.AuthCodeEndPoint = configuration["OAuth:AuthCodeEndPoint"];
			this.TokenEndPoint = configuration["OAuth:TokenEndPoint"];
			this.ClientId = configuration["OAuth:ClientId"];
			this.Secret = configuration["OAuth:Secret"];
			this.Scope = configuration["OAuth:Scope"];
			this.RedirectURI = configuration["OAuth:RedirectURI"];
			this.API_EndPoint = configuration["OAuth:API_EndPoint"];
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

			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accesToken);

			var response1 = await httpClient.GetAsync(API_EndPoint);
			if (response1.IsSuccessStatusCode)
			{
				var jsonRes = JsonSerializer.Deserialize<JsonElement>(
						await response1.Content.ReadAsStringAsync()
					);
				status = $"{(int)response1.StatusCode} {response1.ReasonPhrase}";
				return Ok($"{status + Environment.NewLine}{jsonRes + Environment.NewLine}{response1.IsSuccessStatusCode}");
			}
			else
			{
				return Ok($"{status + Environment.NewLine}{prettyJson + Environment.NewLine}{response.IsSuccessStatusCode}");
			}
			
		}
	}
}
