namespace Dataservices.Domain.Imdb
{
    public class ImdbTitleRatings
    {
        public string Tconst { get; set; }

        public int SumRating { get; set; }

        public int NumVotes { get; set; }
        
        public ImdbTitleBasics Title { get; set; }

    }
}