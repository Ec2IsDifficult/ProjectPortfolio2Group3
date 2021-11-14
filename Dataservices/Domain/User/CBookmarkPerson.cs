namespace Dataservices.Domain.User
{
    public class CBookmarkPerson
    {
        public string Nconst { get; set; }
        public ImdbNameBasics Name { get; set; }
        public int UserId { get; set; }
        //possible object cycle
        public CUser User { get; set; }
        
    }
}