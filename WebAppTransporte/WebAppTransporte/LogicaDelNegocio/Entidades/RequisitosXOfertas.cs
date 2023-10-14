using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class RequisitosXOfertas
    {
        [Key]
        public long idRequisitoXOferta { get; set; }
        public long idOferta { get; set; }
        public long idRequisito { get; set; }
        public string observacion { get; set; }
    }
}

