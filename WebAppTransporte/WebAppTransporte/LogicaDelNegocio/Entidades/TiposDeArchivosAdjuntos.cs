using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeArchivosAdjuntos", Schema = "Admin")]
    public class TiposDeArchivosAdjuntos
    {
        [Key]
        public long idTipoDeArchivoAdjunto { get; set; }
        public string nombreTipoDeArchivoAdjunto { get; set; }
    }
}
