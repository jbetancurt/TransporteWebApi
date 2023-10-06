using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeLugaresXOfertas", Schema = "Admin")]
    public class TiposDeLugaresXOfertas
    {
        [Key]
        public long idTipoDeLugarXOferta { get; set; }
        public string nombreTipoDeLugarXOferta { get; set; }
        public string enumerador { get; set; }
    }
}

