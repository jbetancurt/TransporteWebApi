using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Destinos
    {
        [Key]
        public long idDestino { get; set; }
		public long idContacto { get; set; }
		public long idCiudad { get; set; }
		public string observacionDestino { get; set; }
		public string telefonoDestino { get; set; }
		public string direccionDestino { get; set; }
    }
}
