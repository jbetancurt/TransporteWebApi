using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TTiposOrientacionesDeLaOferta", Schema = "Admin")]
    public class TiposOrientacionesDeLaOferta
    {
        [Key]
        public long idTipoOrientacionDeLaOferta { get; set; }
        public string nombreTipoOrientacionDeLaOferta { get; set; }
    }
}

 