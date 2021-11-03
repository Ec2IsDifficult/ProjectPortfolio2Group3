using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    public class CReviews
    {
        public string Tconst { get; set; }
        public int UserId { get; set; }
        public string Review { get; set; }
        public TimestampAttribute ReviewTimpStamp { get; set; }
        
        public ImdbTitleBasics ReviewFor { get; set; }
        
        public CUser ReviewBy { get; set; }
    }
}