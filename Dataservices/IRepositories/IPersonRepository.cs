using System.Collections.Generic;
using Dataservices.CRUDRepository;
using Dataservices.Domain;

namespace Dataservices.IRepositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.FunctionObjects;

    public interface IPersonRepository : IIMutableRepository<ImdbNameBasics>
    {
        IEnumerable<ImdbKnownFor> GetKnowFor(string id);
        IEnumerable<CoActors> CoActors(string id);
        IEnumerable<ImdbNameBasics> GetPersonsByYear(int year);
        IEnumerable<ImdbPrimeProfession> GetProfessions(string id);
        IEnumerable<ImdbNameBasics> GetRandomPeople(int amount);
    }
}