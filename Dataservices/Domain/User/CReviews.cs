using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    using System;
    using Imdb;

    public class CReviews
    {
        public int UserId { get; set; }
        public CUser ReviewBy { get; set; }
        public string Tconst { get; set; }
        public ImdbTitleBasics ReviewFor { get; set; }
        
        public string Review { get; set; }
        public DateTime ReviewTimeStamp { get; set; }
    }
}