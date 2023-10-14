using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Requisitos
    {
        [Key]
        public long idRequisito { get; set; }
        public long idEmpresa { get; set; }
        public string nombreRequisito { get; set; }
        public bool requeridoAdjunto { get; set; }
        
    }
}
