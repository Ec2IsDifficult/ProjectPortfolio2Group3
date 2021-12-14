using Dataservices.Domain;

namespace WebServiceAPI.Models.PersonViews
{
    public class ProfessionsViewModel
    {
        public string Url { get; set; }
        public string Nconst { get; set; }
        public string Profession { get; set; }
        
        public ImdbNameBasics Name { get; set; }
    }

    public class CreateProfessionsViewModel
    {
        public string Nconst { get; set; }
        public string Profession { get; set; }
        
        public ImdbNameBasics Name { get; set; }
    }
}