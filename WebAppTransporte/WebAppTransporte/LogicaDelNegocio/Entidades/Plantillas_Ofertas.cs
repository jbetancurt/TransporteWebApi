using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TOfertas", Schema = "Plantillas")]
    public class Plantillas_Ofertas
    {
		[Key]
		public long idOferta { get; set; }
		public string Codigo { get; set; }
		public long idDestinoInicio { get; set; }
		public long idDestinoFin { get; set; }
		public long idEmpresa { get; set; }
        public long idTipoOferta { get; set; }
		public string Titulo { get; set; }
		public string Descripcion { get; set; }
		public decimal Alto { get; set; }
		public decimal Ancho { get; set; }
		public decimal Largo { get; set; }
		public decimal Toneladas { get; set; }
		public decimal ValorXTonelada { get; set; }
    }
}
