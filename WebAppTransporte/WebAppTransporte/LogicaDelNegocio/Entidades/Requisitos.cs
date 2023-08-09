using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Requisitos
    {
        [Key]
        public long idRequisito { get; set; }
        public string nombreRequisito { get; set; }
        public long idEmpresa { get; set; }
        public bool requeridoRequisito { get; set; }
        public bool adjuntoRequisito { get; set; }
        public bool validacionUnicaRequisito { get; set; }
    }
}
