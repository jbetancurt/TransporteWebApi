using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class RolesXEmpresas
    {
        [Key]
        public long idRolXEmpresa { get; set; }
        public long idRol { get; set; }
        public long idEmpresa { get; set; }
        public bool activo { get; set; }
    }
}
