using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeEmpresas", Schema = "Admin")]
    public class TiposDeEmpresas
    {
        [Key]
        public long idTipoDeEmpresa { get; set; }
        public string nombreTipoDeEmpresa { get; set; }
    }
}
