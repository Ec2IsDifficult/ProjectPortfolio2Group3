namespace ProjectPortfolioTesting
{
    using System;
    using System.Linq;
    using Dataservices;
    using Dataservices.Repository;
    using Xunit;

    public class UserRepositoryTests
    {
        private UserRepository _userRepository;
        private PersonBookMarkRepository _personBookMarkRepository;
        private TitleBookmarkRepository _titleBookMarkRepository;



        public UserRepositoryTests()
        {
            var _ctx = new ImdbContext();
            _userRepository = new UserRepository(_ctx);
            _personBookMarkRepository = new PersonBookMarkRepository(_ctx);
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
        
        //Use mocking {uid}, {movieConst}, {rating}
        
        [Fact]
        public void TestAddToSearchHistory()
        {
            var uid = 1;
            string searchphrase  = "Asa Akira";
            _userRepository.AddToSearchHistory(uid, searchphrase);
        }
        
        [Fact]
        public void TestRate()
        {
            var uid = 1;
            string movieConst = "ttTEST";
            int rating = 8;
            _userRepository.Rate(uid, movieConst, rating);
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
            string personConst = "nm0000001";
            _userRepository.BookmarkPerson(personConst, uid, false);
            var toBeDeleted = _userRepository.GetPersonBookmarksByUser(1);
            _personBookMarkRepository.Delete(toBeDeleted.FirstOrDefault());
        }
        
        [Fact]
        public void TestBookmarkTitle()
        {
            int uid = 1;
            string movieConst = "tt9025492";
            _userRepository.BookmarkTitle(movieConst, uid, false);
            var toBeDeleted = _userRepository.GetTitleBookmarksByUser(1);
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
            Assert.Equal("New Password", userWithNewPassword.Password);
        }

        [Fact]
        public void TestMockingExample()
        {
            
        }
    }
}