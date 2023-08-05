using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeDocumentos", Schema = "Admin")]
    public class TiposDeDocumentos
    {
        [Key]
        public long idTipoDeDocumento { get; set; }
        public string nombreTipoDeDocumento { get; set; }
    }
}
