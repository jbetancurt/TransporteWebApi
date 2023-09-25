using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Helpers
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IConfiguration configuration;

		public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
		{
			_next = next;
			this.configuration = configuration;
		}

		public async Task Invoke(HttpContext context, IUsuariosServicios loginService)
		{
			var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

			if (token != null)
				attachUserToContext(context, loginService, token);

			await _next(context);
		}

		private void attachUserToContext(HttpContext context, IUsuariosServicios loginService, string token)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"] ?? "");
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					// set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

				// attach user to context on successful jwt validation
				var user = loginService.ConsultarPorId(Convert.ToInt64(userId ?? "-1"));
				context.Items["user"] = user;
			}
			catch (Exception e)
			{
				// do nothing if jwt validation fails
				// user is not attached to context so request won't have access to secure routes
			}
		}
	}
}
