using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TRequisitosXOfertas", Schema = "Plantillas")]
    public class Plantillas_RequisitosXOfertas
    {
        [Key]
        public long idRequisitoXOferta { get; set; }
        public long idOferta { get; set; }
        public long idRequisito { get; set; }
        public bool requeridoRequisitoXOferta { get; set; }
    }
}
