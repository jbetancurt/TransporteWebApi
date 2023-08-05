using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TEstadosPorRutas", Schema = "Admin")]
    public class EstadosPorRutas
    {
        [Key]
        public long idEstadoPorRuta { get; set; }
        public string nombreEstadoPorRuta { get; set; }
    }
}
