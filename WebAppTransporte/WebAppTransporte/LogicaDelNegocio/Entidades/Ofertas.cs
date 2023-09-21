using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Ofertas
    {
        [Key]
        public long idOferta { get; set; }
		public long idEmpresa { get; set; }
		public long idTipoOrientacionDeLaOferta { get; set; }
		public long idEstadoDeLaOferta { get; set; }
		public string tituloOferta { get; set; }
		public string descripcionOferta { get; set; }
	
		public decimal valorTotalDeLaOferta { get; set; }
		public DateTime fechaInicialOferta { get; set; }
		public DateTime fechaFinalOferta { get; set; }
		
    }
}
