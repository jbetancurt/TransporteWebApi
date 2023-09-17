
using Microsoft.Extensions.Options;
using WebAppTransporte.Helpers;
using WebAppTransporte.LogicaDelNegocio.Services.Autenticacion;
namespace WebAppTransporte.Autorizacion
{
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly AppSettings _appSettings;

		public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
		{
			_next = next;
			_appSettings = appSettings.Value;
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

	}
}
