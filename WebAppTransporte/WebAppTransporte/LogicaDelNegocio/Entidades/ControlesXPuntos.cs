using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TControlesXPuntos", Schema = "Admin")]
    public class ControlesXPuntos
    {
        [Key]
        public long idControlXPunto { get; set; }
        public long idTipoDeEmpresa { get; set; }
        public long idAdjunto { get; set; }
        public string nombreControlXPunto { get; set; }
        public string valorControlXPunto { get; set; }
        public long idTipoDePuntoDeControl { get; set; }
        public long idMenu { get; set; }
    }
}
