using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class LugaresXOfertas
    {
        [Key]
        public long idLugarXOferta { get; set; }
        public long idOferta { get; set; }
        public long idEmpresa { get; set; }
        public long idPersona { get; set; }
        public long idCiudad { get; set; }
        public long idTipoDeLugarXOferta { get; set; }
        public int ordenLugarXOferta { get; set; }
        public string nombreLugarXOferta { get; set; }
        public string observacionLugarXOferta { get; set; }
        public string telefonoLugarXOferta { get; set; }
        public string direccionLugarXOferta { get; set; }
        public DateTime fechaEnElLugar { get; set; }
        public int duracionEnLugarXOferta { get; set; }

    }
}
