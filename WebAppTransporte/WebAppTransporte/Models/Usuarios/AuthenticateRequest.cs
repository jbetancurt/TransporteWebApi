using System.ComponentModel.DataAnnotations;

namespace WebAppTransporte.Models.Usuarios
{
	public class AuthenticateRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
