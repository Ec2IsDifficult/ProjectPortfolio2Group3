using System.Collections.Generic;
using Dataservices.Domain;

namespace WebServiceAPI.Models.PersonViews
{
    public class NameBasicsViewModel
    {
        public string Url { get; set; }
        public string Nconst { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public List<ImdbPrimeProfession> ImdbPrimeProfessions { get; set; }
    }

    public class CreateNameBasicsViewModel
    {
        public string Nconst { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public List<ImdbPrimeProfession> ImdbPrimeProfessions { get; set; }
    }
}