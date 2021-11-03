using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    public class CRatingHistory
    {
        public string Tconst { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public TimestampAttribute RatingTimeStamp { get; set; }
        
        public ImdbTitleBasics Title { get; set; }
        
        public CUser User { get; set; }
    }
}