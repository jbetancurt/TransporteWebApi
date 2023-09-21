using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class Lugares
    {
        [Key]
        public long idLugar { get; set; }
        public long idEmpresa { get; set; }
        public long idPersona { get; set; }
        public long idCiudad { get; set; }
        public string observacionLugar { get; set; }
        public string telefonoLugar { get; set; }
        public string direccionLugar { get; set; }
    }
}


       
   