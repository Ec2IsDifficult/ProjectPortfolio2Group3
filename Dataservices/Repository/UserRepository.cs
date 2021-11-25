namespace Dataservices.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain;
    using IRepositories;
    using CRUDRepository;
    using Domain.User;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : MutableRepository<CUser>, IUserRepository
    {
        public UserRepository(ImdbContext context) : base(context)
        {
            
        }

        //in user controller
        public CUser GetReviews(int id)
        {
            return ImdbContext.CUser.Include(x => x.Reviews).FirstOrDefault(x => x.UserId == id);
        }
    
        //in user controller
        public CUser GetRatings(int id)
        {
            return ImdbContext.CUser.Include(x => x.Ratings).FirstOrDefault(x => x.UserId == id);
        }
        
        //in user controller
        public CUser GetSearchHistory(int id)
        {
            return ImdbContext.CUser.Include(x => x.SearchHistories).FirstOrDefault(x => x.UserId == id);
        }
        
        //implemented in user controller
        public void Rate(int uid, string movieConst, int rating)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from rate({uid}, {movieConst}, {rating})");
        }
        //implemented in user controller
        public void AddReview(int uid, string movieConst, string review)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from add_review({movieConst}, {uid}, {review})");
        }
        //implemented in user controller
        public void AddToSearchHistory(int uid, string searchstring)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from add_to_search_history({uid}, {searchstring})");
        }
        //implemented in user controller
        public void BookmarkPerson(string nConst, int uid, bool alreadyMarked)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from person_bookmarking({nConst}, {uid}, {alreadyMarked})");
        }
        //implemented in user controller
        public void BookmarkTitle(string tConst, int uid, bool alreadyMarked)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from title_bookmarking({tConst}, {uid}, {alreadyMarked})");
        }

        //in user controller
        public IEnumerable<CBookmarkTitle> GetTitleBookmarksByUser(int id)
        {
            return ImdbContext.CBookmarkTitle.Where(x => x.UserId == id);
        }

        //in user controller
        public IEnumerable<CBookmarkPerson> GetPersonBookmarksByUser(int id)
        {
            return ImdbContext.CBookmarkPerson.Where(x => x.UserId == id);

        }

        public void CreateUser(string username, string email, string password)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from add_new_user({username}, {email}, {password})");
        }

        public CUser GetUser(string username)
        {
            return ImdbContext.CUser.FirstOrDefault(x => x.UserName == username);
        }

        public void SetNewPassword(int uid, string password)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from set_new_password({uid}, {password})");
        }

        public void UserUpdateEmail(int uid, string email)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from update_user_information({uid}, {email})");
        }

        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}