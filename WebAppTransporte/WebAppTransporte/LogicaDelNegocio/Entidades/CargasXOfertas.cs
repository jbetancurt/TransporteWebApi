using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class CargasXOfertas
    {
        [Key]
        public long idCargaXOferta { get; set; }
        public long idOferta { get; set; }
        public long pesoCargaXOferta { get; set; }
        public long largoCargaXOferta { get; set; }
        public long anchoCargaXOferta { get; set; }
        public long altoCargaXOferta { get; set; }
        public long tarifaCargaXOferta { get; set; }
        public long totalCargaXOferta { get; set; }

    }
}
