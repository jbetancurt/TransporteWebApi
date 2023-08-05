using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Empresas
    {
        [Key]
        public long idEmpresa { get; set; }
		public long idTipoDeEmpresa { get; set; }
		public long idContacto { get; set; }
		public string nombreEmpresa { get; set; }
		public string nitEmpresa { get; set; }
		public string correoEmpresa { get; set; }
		public string telefonoEmpresa { get; set; }
    }
}
