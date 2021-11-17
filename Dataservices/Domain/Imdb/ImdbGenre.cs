namespace Dataservices.Domain
{
    using Imdb;

    public class ImdbGenre
    {
        public string Tconst { get; set; }
        public ImdbTitleBasics Title { get; set; }
        public string Genre { get; set; }
        
    }
}