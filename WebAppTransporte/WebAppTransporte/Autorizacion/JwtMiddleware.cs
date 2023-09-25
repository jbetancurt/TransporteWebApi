
using Microsoft.Extensions.Options;
using WebAppTransporte.Helpers;
using WebAppTransporte.LogicaDelNegocio.Services.Autenticacion;
namespace WebAppTransporte.Autorizacion
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;

		public JwtMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IUsuariosLogeadosService usuarioLogeadoService, IJwtUtils jwtUtils)
		{
			var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
			var userId = jwtUtils.ValidateJwtToken(token);
			if (userId != null)
			{
				// attach user to context on successful jwt validation
				context.Items["User"] = usuarioLogeadoService.ConsultarPorId(userId.Value);
			}

			await _next(context);
		}


		private Task BeginInvoke(HttpContext context)
		{
			if (context.Request.Method == "OPTIONS")
			{
				context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
				context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
				context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
				context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
				context.Response.StatusCode = 200;
				return context.Response.WriteAsync("OK");
			}

			return _next.Invoke(context);
		}

	}
	public static class JwtMiddlewareExtensions
	{
		public static IApplicationBuilder UseJwtMiddlewares(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<JwtMiddleware>();
		}
	}
}

