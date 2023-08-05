using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class PersonasXVehiculos
    {
        [Key]
        public long idPersonaXVehiculo { get; set; }
        public long idPersona { get; set; }
        public long idVehiculo { get; set; }
        public long idTipoPersonaXVehiculo { get; set; }

    }
}
