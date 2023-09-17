namespace WebAppTransporte.Models.Usuarios.MSN
{
	public class UsuarioMSN
	{
		public string id { get; set; }
		public List<string> businessPhones { get; set; } = new List<string>();
		public string displayName { get; set; }
		public string givenName { get; set; }
		public string surname { get; set; }
	}
}
