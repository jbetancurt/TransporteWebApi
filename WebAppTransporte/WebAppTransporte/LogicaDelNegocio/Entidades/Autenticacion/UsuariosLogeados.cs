using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAppTransporte.LogicaDelNegocio.Entidades.Autenticacion
{
    [Table("TUsuariosLogeados", Schema = "Admin")]
    public class UsuariosLogeados
	{
        [Key]
        public long idUsuarioLogeado { get; set; }
		public long idUsuario { get; set; }

		[JsonIgnore]
		public List<RefreshToken> refreshTokens { get; set; }
	}
}
