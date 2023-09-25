using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Usuarios
    {
        [Key]
        public long idUsuario { get; set; }
        public long idPersona { get; set; }
        public string nombreUsuario { get; set; }

		[JsonIgnore]
		public string claveUsuario { get; set; }
        public bool estadoUsuario { get; set; }
		public string codigoExternoUsuario { get; set; }
    }
}
