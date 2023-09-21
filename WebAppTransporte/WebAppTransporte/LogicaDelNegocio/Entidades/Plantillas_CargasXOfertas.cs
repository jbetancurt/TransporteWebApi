using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TPlantillas_CargasXOfertas", Schema = "Plantillas")]
    public class Plantillas_CargasXOfertas
    {
        [Key]
        public long idCargaXOferta { get; set; }
        public long idOferta { get; set; }
        public string nombrePlantillaCargaXOferta { get; set; }
        public long pesoCargaXOferta { get; set; }
        public long largoCargaXOferta { get; set; }
        public long anchoCargaXOferta { get; set; }
        public long altoCargaXOferta { get; set; }
        public long tarifaCargaXOferta { get; set; }
        public long totalCargaXOferta { get; set; }
    }
}
