using DataServices.Authentication;

namespace DataServices.Authentication
{
    public class AuthenticateResponse
    {
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(UserInformation user, string token)
        {
            User_Id = user.User_Id;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
    }
}
