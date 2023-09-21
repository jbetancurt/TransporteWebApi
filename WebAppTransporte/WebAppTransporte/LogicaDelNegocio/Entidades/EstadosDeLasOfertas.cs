
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TEstadosDeLasOfertas", Schema = "Admin")]
    public class EstadosDeLasOfertas
    {
        [Key]
        public long idEstadoDeLaOferta { get; set; }
        public string nombreEstadoDeLaOferta { get; set; }
    }
}
