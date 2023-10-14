using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class CargasXOfertas
    {
        [Key]
        public long idCargaXOferta { get; set; }
        public long idOferta { get; set; }
        public string tipoDeProducto { get; set; }
        public string unidadDeEmpaque { get; set; }         
        public decimal toneladaCargaXOferta { get; set; }
        public decimal largoCargaXOferta { get; set; }
        public decimal anchoCargaXOferta { get; set; }
        public decimal altoCargaXOferta { get; set; }
        public decimal tarifaCargaXOferta { get; set; }
        public decimal totalCargaXOferta { get; set; }


    }
}
