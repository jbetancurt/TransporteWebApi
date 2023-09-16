using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Ofertas
    {
        [Key]
        public long idOferta { get; set; }
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
		public DateTime fechaInicialOferta { get; set; }
		public DateTime fechaFinalOferta { get; set; }
		public string horaInicialOferta { get; set; }
		public bool estadoOferta { get; set; }
    }
}
