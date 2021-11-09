namespace Dataservices.Domain
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ImdbCast
    {
        public string Nconst { get; set; }
        public ImdbNameBasics Name { get; set; }
        
        public string Tconst { get; set; }
        public ImdbTitleBasics Title { get; set; }
        
        public string CharacterName { get; set; }
        public int Rating { get; set; }
        
    }
}