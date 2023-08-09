using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TCiudades", Schema = "Admin")]
    public class Ciudades
    {
        [Key]
        public long idCiudad { get; set; }
        public long idDepartamento { get; set; }
        public string nombreCiudad { get; set; }
        public string codigoCiudad { get; set; }
    }
}
