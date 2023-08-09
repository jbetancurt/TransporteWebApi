using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class PostuladosXOfertas
    {
        [Key]
        public long idPostuladoXOferta { get; set; }
        public long idOferta { get; set; }
        public long idVehiculo { get; set; }
    }
}
