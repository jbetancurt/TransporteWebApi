using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposDeAccionesEnDestinoDeLaRuta", Schema = "Admin")]
    public class TiposDeAccionesEnDestinoDeLaRuta
    {
        [Key]
        public long idTipoDeAccionEnDestinoDeLaRuta { get; set; }
        public string nombreTipoDeAccionEnDestinoDeLaRuta { get; set; }
    }
}
