using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class NotificacionesXOfertas
    {
        [Key]
        public long idNotificacionXOferta { get; set; }
        public long idOferta { get; set; }
        public long idEmpresa { get; set; }
        public long idTipoDeNotificacion { get; set; }
        public long idEstadoDeLaNotificacion { get; set; }
        public bool notificacionRevisada { get; set; }
        
    }
}
