namespace ProjectPortfolioTesting
{
    using System.Linq;
    using Dataservices;
    using Dataservices.Domain;
    using Dataservices.Repository;
    using Xunit;

    public class PersonRepositoryTests
    {
        private ImdbContext _ctx;
        private PersonRepository _personRepository;

        public PersonRepositoryTests()
        {
            _ctx = new ImdbContext();
            _personRepository = new PersonRepository(_ctx);
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
            var actors = _personRepository.CoActors("Lauren Bacall");
            Assert.Contains(actors, x => x.CoActorNconst == "nm0000173");
            Assert.Contains(actors, x => x.CoActorName == "Nicole Kidman");
        }
        
        //[Fact]
        //Need test for CoActors
    }
}