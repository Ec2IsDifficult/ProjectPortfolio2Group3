namespace Dataservices.Domain
{
    using Imdb;

    public class ImdbKnownFor
    {
        public string Nconst { get; set; }
        public ImdbNameBasics Name { get; set; }
        public string Tconst { get; set; }
        public ImdbTitleBasics Title { get; set; }
    }
}