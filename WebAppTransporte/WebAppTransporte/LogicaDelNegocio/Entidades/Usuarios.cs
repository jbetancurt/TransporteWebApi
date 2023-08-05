using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Usuarios
    {
        [Key]
        public long idUsuario { get; set; }
        public long idPersona { get; set; }
        public string nombreUsuario { get; set; }
        public string claveUsuario { get; set; }
        public bool estadoUsuario { get; set; }
    }
}
