using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TOfertas", Schema = "Plantillas")]
    public class Plantillas_Ofertas
    {
		[Key]
		public long idOferta { get; set; }
		public string codigoOferta { get; set; }
		public long idDestinoInicio { get; set; }
		public long idDestinoFin { get; set; }
		public long idEmpresa { get; set; }
        public long idTipoOrientacionDeLaOferta { get; set; }
		public string tituloOferta { get; set; }
		public string descripcionOferta { get; set; }
		public decimal altoOferta { get; set; }
		public decimal anchoOferta { get; set; }
		public decimal largoOferta { get; set; }
		public decimal toneladasOferta { get; set; }
		public decimal valorXToneladaOferta { get; set; }
    }
}

