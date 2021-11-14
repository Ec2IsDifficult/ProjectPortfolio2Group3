namespace Dataservices.Domain.User
{
    using Imdb;

    public class CBookmarkPerson
    {
        public string Nconst { get; set; }
        public ImdbNameBasics Name { get; set; }
        public int UserId { get; set; }
        public CUser User { get; set; }
        
    }
}