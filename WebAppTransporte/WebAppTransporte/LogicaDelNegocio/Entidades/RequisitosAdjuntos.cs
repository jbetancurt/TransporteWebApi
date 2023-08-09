using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class RequisitosAdjuntos
    {
        [Key]
        public long idRequisitoAdjunto { get; set; }
        public long idRequisito { get; set; }
        public long idAdjunto { get; set; }
    }
}
