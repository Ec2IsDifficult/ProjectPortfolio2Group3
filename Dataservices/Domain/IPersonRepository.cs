using System.Collections.Generic;

namespace Dataservices.Domain
{
    public interface IPersonRepository : IRepository<ImdbNameBasics>
    {
        ImdbNameBasics GetKnowFor(int id);
        ImdbNameBasics CoActors(int id);
        ImdbNameBasics GetPersonByYear(int id);
    }
}