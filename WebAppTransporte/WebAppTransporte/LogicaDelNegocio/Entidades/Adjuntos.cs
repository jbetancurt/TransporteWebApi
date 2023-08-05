using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TAdjuntos", Schema = "Admin")]
    public class Adjuntos
    {
        [Key]
        public long idAdjunto { get; set; }
        public long idTipoDeArchivoAdjunto { get; set; }
        public string nombreAdjunto { get; set; }
        public string nombreArchivoAdjunto { get; set; }
    }
}
