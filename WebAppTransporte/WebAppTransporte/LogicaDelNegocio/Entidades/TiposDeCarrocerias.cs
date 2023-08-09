using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeCarrocerias", Schema = "Admin")]
    public class TiposDeCarrocerias
    {
        [Key]
        public long idTipoDeCarroceria { get; set; }
        public string nombreTipoDeCarroceria { get; set; }      
    }
}
