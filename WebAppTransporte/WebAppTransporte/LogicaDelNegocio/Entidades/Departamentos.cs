using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TDepartamentos", Schema = "Admin")]
    public class Departamentos
    {
        [Key]
        public long idDepartamento { get; set; }
        public long idPais { get; set; }
        public string nombreDepartamento { get; set; }
        public string codigoDepartamento { get; set; }
    }
}
