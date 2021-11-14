namespace Dataservices.Domain.User
{
    public class CBookmarkTitle
    {
        public string Tconst { get; set; }
        public ImdbTitleBasics Title { get; set; }
        public int UserId { get; set; }
        //possible object cycle
        //public CUser User { get; set; }
    }
}