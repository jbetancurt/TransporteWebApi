using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TPaises", Schema = "Admin")]
    public class Paises
    {
        [Key]
        public long idPais { get; set; }
        public string nombrePais { get; set; }
        public string codigoPais { get; set; }

    }
}
