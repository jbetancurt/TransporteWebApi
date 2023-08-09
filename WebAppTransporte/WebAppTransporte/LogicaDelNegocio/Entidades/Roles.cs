using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TRoles", Schema = "Admin")]
    public class Roles
    {
        [Key]
        public long idRol { get; set; }
        public long idTipoDeRol { get; set; }
        public string nombreRol { get; set; }
    }
}
