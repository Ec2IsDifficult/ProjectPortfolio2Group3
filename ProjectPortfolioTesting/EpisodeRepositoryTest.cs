namespace ProjectPortfolioTesting
{
    using System.Linq;
    using Dataservices;
    using Dataservices.Repository;
    using Xunit;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


    public class EpisodeRepositoryTest
    {
        private EpisodeRepository _episodeRepository;


        public EpisodeRepositoryTest( )
        {
            _episodeRepository = new EpisodeRepository(DbcontextFactory);
        }
        
        public ImdbContext DbcontextFactory() 
        {
            return new ImdbContext();
        }

        [Fact]
        public void TestGetEpisodeCast()
        {
            var res = _episodeRepository.GetEpisodeCast("tt11872474");
            Assert.Contains(res, x => x.MainTitle.Cast.Count == 2);

        }
        
        [Fact]
        public void TestGetEpisodeCrew()
        {
            var res = _episodeRepository.GetEpisodeCrew("tt11872474");
            Assert.Contains(res, x => x.MainTitle.Crew.Count == 9);

        }
        
    }
}