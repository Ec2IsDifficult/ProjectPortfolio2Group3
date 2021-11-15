namespace Dataservices.Domain.Imdb
{
    public class ImdbTitleEpisode
    {
        public string Tconst { get; set; }
        public string EpisodeTconst { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }
        //creates object cycle
        //public ImdbTitleBasics MainTitle { get; set; }

    }
}