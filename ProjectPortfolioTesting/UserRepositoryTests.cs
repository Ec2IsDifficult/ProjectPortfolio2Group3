namespace ProjectPortfolioTesting
{
    using System;
    using Dataservices;
    using Dataservices.Repository;
    using Xunit;

    public class UserRepositoryTests
    {
        private UserRepository _userRepository;

        public UserRepositoryTests()
        {
            var _ctx = new ImdbContext();
            _userRepository = new UserRepository(_ctx);
        }

        [Fact]
        public void GetUserReviewsTest()
        {
            var user = _userRepository.GetReviews(1);
            Assert.Contains(user.Reviews, x => x.Review == "new review");
            Assert.Contains(user.Reviews, x => x.Review == "newesT! review");
        }
        
        [Fact]
        public void GetUserRatingsTest()
        {
            var user = _userRepository.GetRatings(1);
            Assert.Contains(user.Ratings, x => x.Rating == 8);
            Assert.Contains(user.Ratings, x => x.Rating == 5);
        }
        
        [Fact]
        public void GetSearchHistoryTest()
        {
            var user = _userRepository.GetSearchHistory(1);
            Assert.Contains(user.SearchHistories, x => x.SearchPhrase == "World");
            Assert.Contains(user.SearchHistories, x => x.SearchPhrase == "Hello World");
        }
    }
}