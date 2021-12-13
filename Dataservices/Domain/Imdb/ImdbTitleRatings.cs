using System;

namespace Dataservices.Domain.Imdb
{
    public class ImdbTitleRatings
    {
        public string Tconst { get; set; }

        public int SumRating { get; set; }

        public int NumVotes { get; set; }
        
        //object cycle
        //public ImdbTitleBasics Title { get; set; }

        public double Rating => Math.Round((float)SumRating /NumVotes, 1);

    }
}