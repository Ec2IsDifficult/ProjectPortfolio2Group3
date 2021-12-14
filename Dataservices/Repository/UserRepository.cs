namespace Dataservices.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : MutableRepository<CUser>, IUserRepository
    {
        public UserRepository(Func<DbContext> contextFactory) : base(contextFactory)
        {
        }
        //in user controller
        public CUser GetReviews(int id)
        {
            var ctx = new ImdbContext();
            return ctx.CUser.Include(x => x.Reviews).FirstOrDefault(x => x.UserId == id);
        }
    
        //in user controller
        public CUser GetRatings(int id)
        {
            var ctx = new ImdbContext();
            return ctx.CUser.Include(x => x.Ratings).FirstOrDefault(x => x.UserId == id);
        }
        
        //in user controller
        public CUser GetSearchHistory(int id)
        {
            var ctx = new ImdbContext();
            return ctx.CUser.Include(x => x.SearchHistories).FirstOrDefault(x => x.UserId == id);
        }
        
        //implemented in user controller
        public void Rate(int uid, string movieConst, int rating)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from rate({uid}, {movieConst}, {rating})");
        }
        //implemented in user controller
        public void AddReview(int uid, string movieConst, string review)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from add_review({movieConst}, {uid}, {review})");
        }
        //implemented in user controller
        public void AddToSearchHistory(int uid, string searchstring)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from add_to_search_history({uid}, {searchstring})");
        }
        //implemented in user controller
        public void BookmarkPerson(string nConst, int uid, bool alreadyMarked)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from person_bookmarking({nConst}, {uid}, {alreadyMarked})");
        }
        //implemented in user controller
        public void BookmarkTitle(string tConst, int uid, bool alreadyMarked)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from title_bookmarking({tConst}, {uid}, {alreadyMarked})");
        }

        //in user controller
        public IEnumerable<CBookmarkTitle> GetTitleBookmarksByUser(int id)
        {
            var ctx = new ImdbContext();
            return ctx.CBookmarkTitle.Where(x => x.UserId == id);
        }

        //in user controller
        public IEnumerable<CBookmarkPerson> GetPersonBookmarksByUser(int id)
        {
            var ctx = new ImdbContext();
            return ctx.CBookmarkPerson.Where(x => x.UserId == id);

        }

        public void CreateUser(string username, string email, string password)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from add_new_user({username}, {email}, {password})");
        }

        public CUser GetUser(string username)
        {
            var ctx = new ImdbContext();
            return ctx.CUser.FirstOrDefault(x => x.UserName == username);
        }

        public void SetNewPassword(int uid, string password)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from set_new_password({uid}, {password})");
        }

        public void UserUpdateEmail(int uid, string email)
        {
            var ctx = new ImdbContext();
            ctx.Database.ExecuteSqlInterpolated($"select * from update_user_information({uid}, {email})");
        }
    }
}