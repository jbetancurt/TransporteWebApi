using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TMenus", Schema = "Admin")]
    public class Menus
    {
        [Key]
        public long idMenu { get; set; }
        public long idMenuPadre { get; set; }
        public string nombre { get; set; }
        public string nombreController { get; set; }
        public string nombreAction { get; set; }
        public bool esNodo { get; set; }
        public bool activo { get; set; }
    }
}
