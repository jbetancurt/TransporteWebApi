using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeRequisitos", Schema = "Admin")]
    public class TiposDeRequisitos
    {
        [Key]
        public long idTipoDeRequisito { get; set; }
        public string nombreTipoDeRequisito { get; set; }
    }
}
