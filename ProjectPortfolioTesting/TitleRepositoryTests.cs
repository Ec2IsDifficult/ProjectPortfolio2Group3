namespace ProjectPortfolioTesting
{
    using System.Linq;
    using Dataservices;
    using Dataservices.Repository;
    using Xunit;

    public class TitleRepositoryTests
    {
        private TitleRepository _titleRepository;
        
        public TitleRepositoryTests()
        {
            var ctx = new ImdbContext();
            _titleRepository = new TitleRepository(ctx);
        }

        [Fact]
        public void GetTitlesByYearTest()
        {
            var titlesByYear = _titleRepository.GetTitlesByYear(1959);
            Assert.Equal("The Twilight Zone",titlesByYear.First().PrimaryTitle);
            Assert.Equal("Where Is Everybody?",titlesByYear.Last().PrimaryTitle);
        }

        [Fact]
        public void GetCast()
        {
            var titles = _titleRepository.GetCast("tt0052520");
            Assert.Contains(titles.Cast, x => x.Nconst == "nm0785245");
            Assert.Contains(titles.Cast, x => x.Nconst == "nm0877244");
        }
        
        [Fact]
        public void GetCrew()
        {
            var titles = _titleRepository.GetCrew("tt9025492");
            Assert.Contains(titles.Crew, x => x.Nconst == "nm5970972");
        }
        
        [Fact]
        public void GetRating()
        {
            var titles = _titleRepository.GetRating("tt9025492");
            Assert.Equal(5499, titles.SumRating);
            Assert.Equal(646, titles.NumVotes);
        }
        
        [Fact]
        public void GetEpisodes()
        {
            var titles = _titleRepository.GetEpisodes("tt9025492");
            Assert.Contains(titles.Episodes, x => x.EpisodeTconst == "tt11576432");
            Assert.Contains(titles.Episodes, x => x.EpisodeTconst == "tt11598718");        
        }
    }
}