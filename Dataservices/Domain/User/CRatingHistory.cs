using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    public class CRatingHistory
    {
        public string Tconst { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        //TODO: Is this the correct attribute
        public TimestampAttribute RatingTimeStamp { get; set; }

    }
}