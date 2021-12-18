namespace ProjectPortfolioTesting
{
    using System.Linq;
    using Dataservices;
    using Dataservices.Domain;
    using Dataservices.Repository;
    using Xunit;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


    public class PersonRepositoryTests
    {
        private PersonRepository _personRepository;


        public PersonRepositoryTests()
        {
            _personRepository = new PersonRepository(DbcontextFactory);
        }
        
        public ImdbContext DbcontextFactory() 
        {
            return new ImdbContext();
        }

        [Fact]
        public void PersonKnownForTests()
        {
            var knowFors = _personRepository.GetKnowFor("nm0000085");
            Assert.Equal("tt1825758", knowFors.First().Tconst);
        }

        [Fact]
        public void GetPersonByYearTest()
        {
            var person = _personRepository.GetPersonsByYear(1265);
            Assert.Equal("nm0019604", person.First().Nconst);
        }

        [Fact]
        public void TestGetCoActors()
        {
            var actors = _personRepository.CoActors("nm0000002");
            Assert.Contains(actors, x => x.CoActorNconst == "nm0000173");
            Assert.Contains(actors, x => x.CoActorName == "Nicole Kidman");
        }
    }
}