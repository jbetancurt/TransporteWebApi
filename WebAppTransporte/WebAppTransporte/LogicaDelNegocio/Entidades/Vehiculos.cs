using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Vehiculos
    {
		[Key]	
		public long idVehiculo { get; set; }
		public long idCarroceriaXTipoVehiculo { get; set; }
		public long idTipoDeCarroceria { get; set; }
		public long idTipoVehiculo { get; set; }
		public string placaVehiculo { get; set; }
		public string placaTrailerVehiculo { get; set; }
    }
}
