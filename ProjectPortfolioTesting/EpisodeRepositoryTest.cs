namespace ProjectPortfolioTesting
{
    using System.Linq;
    using Dataservices;
    using Dataservices.Repository;
    using Xunit;

    public class EpisodeRepositoryTest
    {
        private EpisodeRepository _episodeRepository;
        private ImdbContext _ctx;

        public EpisodeRepositoryTest()
        {
            _ctx = new ImdbContext();
            _episodeRepository = new EpisodeRepository(_ctx);
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
        
        [Fact]
        public void TestGetEpisodeRating()
        {
            var res = _episodeRepository.GetEpisodeRating("tt11872474");
            Assert.Contains(res, x => x.MainTitle.Rating.NumVotes == 376);
        }
    }
}