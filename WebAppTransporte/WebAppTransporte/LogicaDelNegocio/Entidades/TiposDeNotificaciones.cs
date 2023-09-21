using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class TiposDeNotificaciones
    {
        [Key]
        public long idTipoDeNotificacion { get; set; }
        public string nombreTipoDeNotificacion { get; set; }
    }
}
