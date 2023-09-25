using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Helpers
{
	public class TransporteAuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		private bool required = false;
		public TransporteAuthorizeAttribute(string[] roles)
		{
			this.configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
			if (roles != null && roles.Length > 0)
			{
				required = false;

			}
			else
			{
				required = true;
			}


		}
		private readonly IConfiguration configuration;
		public TransporteAuthorizeAttribute()
		{
			this.configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
		}
		public string Policy { get; set; }

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			//if (!required)
			//{
			//    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
			//}
			//else
			//{


			//}
			var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
			if (token == null)
			{
				context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
			}


			var user = (Usuarios)context.HttpContext.Items["user"];
			if (user == null)
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

				var optionsBuilder = new DbContextOptionsBuilder<DbContextsTransporte>();
				optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConexionDb"));
				var _context = new DbContextsTransporte(optionsBuilder.Options);
				var user1 = _context.TUsuarios.Where(x => x.idUsuario == Convert.ToInt64(userId ?? "-1")).FirstOrDefault();
				if (user1 != null && user1.idUsuario > 0)
				{
					context.HttpContext.Items["user"] = user1;

				}
				else
				{
					context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

				}

			}


		}
	}
}
