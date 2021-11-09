using System.ComponentModel.DataAnnotations;

namespace DataServices.Authentication
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
