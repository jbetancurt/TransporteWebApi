using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeVehiculos", Schema = "Admin")]
    public class TiposDeVehiculos
    {
        [Key]
        public long idTipoDeVehiculo { get; set; }
        public string nombreTipoDeVehiculo { get; set; }
    }
}
