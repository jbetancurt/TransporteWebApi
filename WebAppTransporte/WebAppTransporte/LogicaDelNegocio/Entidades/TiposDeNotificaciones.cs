using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeNotificaciones", Schema = "Admin")]
    public class TiposDeNotificaciones
    {
        [Key]
        public long idTipoDeNotificacion { get; set; }
        public string nombreTipoDeNotificacion { get; set; }
    }
}
