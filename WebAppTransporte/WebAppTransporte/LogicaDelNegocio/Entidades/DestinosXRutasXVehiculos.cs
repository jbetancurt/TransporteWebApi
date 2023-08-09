using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class DestinosXRutasXVehiculos
    {
        [Key]
        public long idDestinoXRutaXVehiculo { get; set; }
		public long idRutaXVehiculo { get; set; }
		public long idCiudad { get; set; }
		public long idTipoDeAccionDestinoXRutaXVehiculo { get; set; }
		public DateTime fechaDestinoXRutaXVehiculo { get; set; }
		public int ordenDestinoXRutaXVehiculo { get; set; }
		public string observacionDestinoXRutaXVehiculo { get; set; }
		public string telefonoDestinoXRutaXVehiculo { get; set; }
		public string direccionDestinoXRutaXVehiculo { get; set; }
		public int duracionEnDestinoXRutaXVehiculo { get; set; }
    }
}
