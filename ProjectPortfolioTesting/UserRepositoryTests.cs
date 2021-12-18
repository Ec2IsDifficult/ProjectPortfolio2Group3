namespace ProjectPortfolioTesting
{
    using System;
    using System.Linq;
    using Dataservices;
    using Dataservices.Repository;
    using Xunit;
    using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


    public class UserRepositoryTests
    {
        private UserRepository _userRepository;
        private PersonBookMarkRepository _personBookMarkRepository;
        private TitleBookmarkRepository _titleBookMarkRepository;

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository(DbcontextFactory);
            _personBookMarkRepository = new PersonBookMarkRepository(DbcontextFactory);
            _titleBookMarkRepository = new TitleBookmarkRepository(DbcontextFactory);
        }
        
        public ImdbContext DbcontextFactory() 
        {
            return new ImdbContext();
        }

        [Fact]
        public void GetUserReviewsTest()
        {
            var user = _userRepository.GetReviews(1);
            Assert.Contains(user.Reviews, x => x.Review == "new review");
            Assert.Contains(user.Reviews, x => x.Review == "Sick movie");
        }
        
        [Fact]
        public void GetUserRatingsTest()
        {
            var user = _userRepository.GetRatings(2);
            Assert.Contains(user.Ratings, x => x.Rating == 2);
        }

        [Fact]
        public void GetSearchHistoryTest()
        {
            var user = _userRepository.GetSearchHistory(1);
            Assert.Contains(user.SearchHistories, x => x.SearchPhrase == "World");
            Assert.Contains(user.SearchHistories, x => x.SearchPhrase == "Hello World");
        }

        //Use mocking {uid}, {movieConst}, {rating}
        
        [Fact]
        public void TestAddToSearchHistory()
        {
            var uid = 1;
            string searchphrase  = "Hello";
            _userRepository.AddToSearchHistory(uid, searchphrase);
        }

        [Fact]
        public void TestAddReview()
        {
            var uid = 1;
            string movieConst = "ttTEST";
            string review  = "The greatest review of them all";
            _userRepository.AddReview(uid, movieConst, review);
        }
        
        [Fact]
        public void TestBookmarkPerson()
        {
            int uid = 1;
            string personConst = "nm0000007";
            _userRepository.BookmarkPerson(personConst, uid, false);
            var toBeDeleted = _userRepository.GetPersonBookmarksByUser(uid).Where(x => x.Nconst == personConst);
            _personBookMarkRepository.Delete(toBeDeleted.FirstOrDefault());
        }
        
        [Fact]
        public void TestBookmarkTitle()
        {
            int uid = 1;
            string movieConst = "tt0063929";
            _userRepository.BookmarkTitle(movieConst, uid, false);
            var toBeDeleted = _userRepository.GetTitleBookmarksByUser(uid).Where(x => x.Tconst == movieConst);
            _titleBookMarkRepository.Delete(toBeDeleted.FirstOrDefault());
        }
        
        [Fact] 
        public void TestGetTitleBookmarksByUser()
        {
            int uid = 1;
            var res = _userRepository.GetTitleBookmarksByUser(1);
            Assert.Contains(res, x => x.Tconst == "tt9025492");
        }
        
        [Fact] 
        public void TestGetPersonBookmarksByUser()
        {
            int uid = 1;
            var res = _userRepository.GetPersonBookmarksByUser(1);
            Assert.Contains(res, x => x.Nconst == "nm0000001");
        }

        [Fact]
        public void TestSetNewPassword()
        {
            int uid = 1;
            string newPassword = "New Password";
            _userRepository.SetNewPassword(uid, newPassword);
            var userWithNewPassword = _userRepository.Get(1);
            Assert.Equal("ae3bb2a1ac61750150b606298091d38a", userWithNewPassword.Password);
        }
    }
}