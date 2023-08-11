using System.Text.Json.Serialization;

namespace WebAppTransporte.LogicaDelNegocio.Entidades.Autenticacion
{
	public class UsuariosLogeados
	{
		public long idUsuarioLogeado { get; set; }
		public long idUsuario { get; set; }

		[JsonIgnore]
		public List<RefreshToken> refreshTokens { get; set; }
	}
}
