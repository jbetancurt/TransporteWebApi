using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
    public class HistorialesDeLasOfertas
    {
        [Key]
        public long idHistorialDeLaOferta { get; set; }
        public long idUsuario { get; set; }
        public long idOferta { get; set; }
        public long idEmpresa { get; set; }
        public string valorActual { get; set; }
        public string valorAnterior { get; set; }
        public DateTime fechaDelSuceso { get; set; }
        public int versionJson { get; set; }

       
    }
}

