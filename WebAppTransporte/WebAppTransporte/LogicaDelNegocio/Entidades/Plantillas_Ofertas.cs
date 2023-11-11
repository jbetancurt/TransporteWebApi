using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TOfertas", Schema = "Plantillas")]
    public class Plantillas_Ofertas
    {
        [Key]
        public long idOferta { get; set; }
        public long idEmpresa { get; set; }
        public long idTipoOrientacionDeLaOferta { get; set; }
        public long idTipoDePlantillaOferta { get; set; }
        public string nombrePlantillaOferta { get; set; }
        public string tituloOferta { get; set; }
        public string descripcionOferta { get; set; }

        public decimal valorTotalDeLaOferta { get; set; }
        
    }
}

