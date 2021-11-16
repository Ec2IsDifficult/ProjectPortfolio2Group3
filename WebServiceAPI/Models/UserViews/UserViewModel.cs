namespace WebServiceAPI.Models.UserViews
{
    public class UserViewModel
    {
        public string Url { get; set; }
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserViewModel
    {
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}