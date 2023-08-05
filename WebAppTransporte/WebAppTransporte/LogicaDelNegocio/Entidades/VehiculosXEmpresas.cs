using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class VehiculosXEmpresas
    {
        [Key]
        public long idVehiculoXEmpresa { get; set; }
        public long idEmpresa { get; set; }
        public long idVehiculo { get; set; }
    }
}
