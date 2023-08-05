using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TCarroceriasXTiposDeVehiculos", Schema = "Admin")]
    public class CarroceriasXTiposDeVehiculos
    {
        [Key]
        public long idCarroceriaXTipoDeVehiculo { get; set; }
        public long idTipoDeVehiculo { get; set; }
        public long idTipoDeCarroceria { get; set; }
        public bool tieneTrailer { get; set; }
    }
}
