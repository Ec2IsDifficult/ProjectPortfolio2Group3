using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    using System;

    public class CRatingHistory
    {
        public string Tconst { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public DateTime RatingTimeStamp { get; set; }
        
        public ImdbTitleBasics Title { get; set; }
        
        public CUser User { get; set; }
    }
}