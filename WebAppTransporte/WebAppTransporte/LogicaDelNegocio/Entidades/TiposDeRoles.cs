using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeRoles", Schema = "Admin")]
    public class TiposDeRoles
    {
        [Key]
        public long idTipoDeRol { get; set; }
        public string nombreTipoDeRol { get; set; }
    }
}
