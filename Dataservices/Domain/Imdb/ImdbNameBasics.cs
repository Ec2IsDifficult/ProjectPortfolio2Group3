using System.Collections.Generic;
using Dataservices.Domain.User;

namespace Dataservices.Domain
{
    public class ImdbNameBasics
    {
        public string Nconst { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public List<ImdbKnownFor> KnownFors { get; set; }
        public List<ImdbCrew> ImdbCrews { get; set; }
        public List<ImdbCast> ImdbCasts { get; set; }
        public List<ImdbPrimeProfession> ImdbPrimeProfessions { get; set; }
        public List<CBookmarkPerson> BookmarkPersons { get; set; }
    }
}