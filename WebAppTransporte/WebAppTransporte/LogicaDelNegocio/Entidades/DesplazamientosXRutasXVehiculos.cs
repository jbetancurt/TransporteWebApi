using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class DesplazamientosXRutasXVehiculos
    {
        [Key]
        public long idDesplazamientoXRutaXVehiculo { get; set; }
        public long idRutaXVehiculo { get; set; }
        public DateTime fechaDesplazamientoXRutaXVehiculo { get; set; }
        public DateTime horaDesplazamientoXRutaXVehiculo { get; set; }
    }
}
