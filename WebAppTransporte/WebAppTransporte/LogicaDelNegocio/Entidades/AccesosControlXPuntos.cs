using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class AccesosControlXPuntos
    {
        [Key]
        public long idAccesoControlXPunto { get; set; }
        public long idEmpresa { get; set; }
        public long idControlXPunto { get; set; }
        public long idRol { get; set; }
    }
}
