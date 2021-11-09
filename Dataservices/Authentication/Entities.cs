using System;
using DataServices.Authentication;

namespace DataServices.Authentication
{
    public class UserInformation
    {
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
