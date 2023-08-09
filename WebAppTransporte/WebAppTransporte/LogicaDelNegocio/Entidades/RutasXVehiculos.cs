using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class RutasXVehiculos
    {
        [Key]
        public long idRutaXVehiculo { get; set; }
		public string nombreRutaXVehiculo { get; set; }
		public string descripcionRutaXVehiculo { get; set; }
		public long idVehiculo { get; set; }
		public long idEmpresaLogistica { get; set; }
		public long idEmpresaContratante { get; set; }
		public long idEstadoRuta { get; set; }
		public DateTime fechaInicioRutaXVehiculo { get; set; }
		public DateTime fechaInicioRealRutaXVehiculo { get; set; }
		public DateTime fechaFinRutaXVehiculo { get; set; }
		public DateTime fechaFinRealRutaXVehiculo { get; set; }
    }
}
