using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class EstadosDeLasNotificaciones
    {
        [Key]
        public long idEstadoDeLaNotificacion { get; set; }
        public string nombreEstadoDeLaNotificacion { get; set; }
    }
}
