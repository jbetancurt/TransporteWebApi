using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class DestinosXEmpresas
    {
        [Key]
        public long idDestinoXEmpresa { get; set; }
        public long idDestino { get; set; }
        public long idEmpresa { get; set; }
        public long idEmpresaSecundaria { get; set; }
    }
}
