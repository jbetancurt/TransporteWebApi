using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposOrientacionesDeLaOferta", Schema = "Admin")]
    public class TiposOrientacionesDeLaOferta
    {
        [Key]
        public long idTipoOrientacionOferta { get; set; }
        public string nombreTipoOrientacionOferta { get; set; }
    }
}
