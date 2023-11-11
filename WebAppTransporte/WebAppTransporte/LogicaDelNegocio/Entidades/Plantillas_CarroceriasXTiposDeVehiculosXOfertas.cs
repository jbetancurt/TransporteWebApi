using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TCarroceriasXTiposDeVehiculosXOfertas", Schema = "Plantillas")]
    public class Plantillas_CarroceriasXTiposDeVehiculosXOfertas
    {
        [Key]
        public long idCarroceriaXTipoDeVehiculoXOferta { get; set; }
        public long idOferta { get; set; }
        public long idTipoDeVehiculo { get; set; }
        public long idTipoDeCarroceria { get; set; }
        public bool tieneTrailer { get; set; }
        public string descripcion { get; set; }
    }
}




