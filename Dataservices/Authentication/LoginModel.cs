using System.ComponentModel.DataAnnotations;

namespace DataServices.Authentication
{
    public class LoginRequestModel
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
