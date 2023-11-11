using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDePlantillasOfertas", Schema = "Admin")]
    public class TiposDePlantillasOfertas
    {
        [Key]
        public long idTipoDePlantillaOferta { get; set; }
        public string nombreTipoDePlantillaOferta { get; set; }
        public string enumerador { get; set; }
    }
   
}
