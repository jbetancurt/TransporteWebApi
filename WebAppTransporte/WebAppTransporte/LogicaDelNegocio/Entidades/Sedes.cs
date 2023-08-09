using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Sedes
    {
        [Key]
        public long idSede { get; set; }
		public long idEmpresa { get; set; }
		public long idCiudad { get; set; }
		public long idContacto { get; set; }
		public string nombreSede { get; set; }
		public string telefonoSede { get; set; }
		public string direccionSede { get; set; }
    }
}
