using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    [Table("TLugaresXOfertas", Schema = "Plantillas")]
    public class Plantillas_LugaresXOfertas
    {
       

        [Key]
        public long idLugarXOferta { get; set; }
        public long idOferta { get; set; }
        public long idEmpresa { get; set; }
        public long idPersona { get; set; }
        public long idCiudad { get; set; }
        public long idTipoDeLugarXOferta { get; set; }
        public long nombrePlantillaLugarXOferta { get; set; }
        public string nombreLugar { get; set; }
        public string observacionLugar { get; set; }
        public string telefonoLugar { get; set; }
        public string direccionLugar { get; set; }
    }
}
