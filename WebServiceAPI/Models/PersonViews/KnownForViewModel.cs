using Dataservices.Domain;

namespace WebServiceAPI.Models.PersonViews
{
    public class KnownForViewModel
    {
        public string Url { get; set; }
        public ImdbNameBasics Name { get; set; }
        public ImdbTitleBasics Title { get; set; }
    }

    public class CreateKnownForViewModel
    {
        public ImdbNameBasics Name { get; set; }
        public ImdbTitleBasics Title { get; set; } 
    }
}