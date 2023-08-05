using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDePersonasPorVehiculos", Schema = "Admin")]
    public class TiposDePersonasPorVehiculos
    {
        [Key]
        public long idTipoDePersonaPorVehiculo { get; set; }

        public string nombreTipoDePersonaPorVehiculo { get; set; }

    }
}
