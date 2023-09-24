using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TEstadosDeLasNotificaciones", Schema = "Admin")]
    public class EstadosDeLasNotificaciones
    {
        [Key]
        public long idEstadoDeLaNotificacion { get; set; }
        public string nombreEstadoDeLaNotificacion { get; set; }
    }
}
