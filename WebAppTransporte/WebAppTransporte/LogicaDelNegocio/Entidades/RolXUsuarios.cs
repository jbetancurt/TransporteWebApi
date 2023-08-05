using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class RolXUsuarios
    {
        [Key]
        public long idRolXUsuario { get; set; }
        public long idRol { get; set; }
        public long idUsuario { get; set; }
        public bool activo { get; set; }
    }
}
