using System.Text.Json.Serialization;
using WebAppTransporte.LogicaDelNegocio.Entidades.Autenticacion;

namespace WebAppTransporte.Models.Usuarios
{
	public class AuthenticateResponse
	{
		public long idUsuarioLogeado { get; set; }
		public long idUsuario { get; set; }
		public string JwtToken { get; set; }

		[JsonIgnore] // refresh token is returned in http only cookie
		public string RefreshToken { get; set; }

		public AuthenticateResponse(UsuariosLogeados user, string jwtToken, string refreshToken)
		{
			idUsuarioLogeado = user.idUsuarioLogeado;
			idUsuario = user.idUsuario;
			JwtToken = jwtToken;
			RefreshToken = refreshToken;
		}
	}
}
