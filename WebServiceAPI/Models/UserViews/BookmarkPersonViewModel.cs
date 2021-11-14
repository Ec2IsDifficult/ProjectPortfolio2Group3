using Dataservices.Domain;

namespace WebServiceAPI.Models.UserViews
{
    public class BookmarkPersonViewModel
    {
        public string Url { get; set; }
        public ImdbNameBasics Name { get; set; }
        public int UserId { get; set; }
    }

    public class CreateBookmarkPersonViewModel
    {
        public ImdbNameBasics Name { get; set; }
        public int UserId { get; set; }
    }
}