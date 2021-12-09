using Dataservices.Domain;

namespace WebServiceAPI.Models
{
    using Dataservices.Domain.Imdb;

    public class RatingViewModel
    {
        public string Url { get; set; }
        public int SumRating { get; set; }

        public int NumVotes { get; set; }
        
        //public ImdbTitleBasics Title { get; set; }
        public float Rating { get; set; }
    }

    public class CreateRatingViewModel
    {
        public int SumRating { get; set; }

        public int NumVotes { get; set; }
        
        //public ImdbTitleBasics Title { get; set; }
        public float Rating { get; set; }
    }
}