using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDePuntosDeControl", Schema = "Admin")]
    public class TiposDePuntosDeControl
    {
        [Key]
        public long idTipoDePuntoDeControl { get; set; }
        public string nombreTipoDePuntoDeControl { get; set; }
    }
}
