using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TCargasXOfertas", Schema = "Plantillas")]
    public class Plantillas_CargasXOfertas
    {
        [Key]
        public long idCargaXOferta { get; set; }
        public long idOferta { get; set; }
        public string nombrePlantillaCargaXOferta { get; set; }
        public decimal altoCargaXOferta { get; set; }
        public decimal anchoCargaXOferta { get; set; }
        public decimal largoCargaXOferta { get; set; }
        public decimal toneladaCargaXOferta { get; set; }
        public decimal tarifaCargaXOferta { get; set; }
        public decimal totalCargaXOferta { get; set; }
    }
}
