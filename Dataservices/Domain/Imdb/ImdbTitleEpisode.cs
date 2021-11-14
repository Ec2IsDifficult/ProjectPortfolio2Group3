namespace Dataservices.Domain
{
    public class ImdbTitleEpisode
    {
        public string Tconst { get; set; }
        public string EpisodeTconst { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }
        
        //causes possible object cycle
        //public ImdbTitleBasics MainTitle { get; set; }

    }
}