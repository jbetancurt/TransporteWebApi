using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class SedesEmpleados
    {
        [Key]
        public long idSedeEmpleado { get; set; }
        public long idSede { get; set; }
        public long idPersona { get; set; }
        public bool estadoSedeEmpleado { get; set; }
        public string telefonoContactoSedeEmpleado { get; set; }
    }
}
