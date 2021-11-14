using Dataservices.Domain;

namespace WebServiceAPI.Models
{
    public class RatingViewModel
    {
        public string Url { get; set; }
        public int SumRating { get; set; }

        public int NumVotes { get; set; }
        
        public ImdbTitleBasics Title { get; set; }
    }

    public class CreateRatingViewModel
    {
        public int SumRating { get; set; }

        public int NumVotes { get; set; }
        
        public ImdbTitleBasics Title { get; set; }
    }
}