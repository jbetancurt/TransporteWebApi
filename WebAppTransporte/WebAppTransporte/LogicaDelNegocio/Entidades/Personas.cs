using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.LogicaDelNegocio.Entidades
{
	public class Personas
	{
        [Key]
        public long idPersona { get; set; }
		public string nombre1Persona { get; set; }
		public string nombre2Persona { get; set; }
		public string apellido1Persona { get; set; }
		public string apellido2Persona { get; set; }
		public string nombreCompletoPersona { get; set; }
		public string documentoDeIdentidadPersona { get; set; }
		public long idTipoDeDocumentoPersona { get; set; }
		public string correoPersona { get; set; }
		public string telefonoPersona { get; set; }
		public string telefonoOtroPersona { get; set; }
		public string direccionPersona { get; set; }
	}
}
