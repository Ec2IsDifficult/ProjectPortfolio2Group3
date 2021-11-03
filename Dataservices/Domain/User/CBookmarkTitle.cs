namespace Dataservices.Domain.User
{
    public class CBookmarkTitle
    {
        public string Tconst { get; set; }
        public int UserId { get; set; }
        
        public ImdbTitleBasics Title { get; set; }
        public CUser User { get; set; }
    }
}