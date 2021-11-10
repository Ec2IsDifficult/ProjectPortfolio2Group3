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

        public CUser GetReviews(int id)
        {
            //TODO: Should we make one more function for only getting one review based on TConst
            return ImdbContext.CUser.Include(x => x.Reviews).FirstOrDefault(x => x.UserId == id);
        }

        public CUser GetRatings(int id)
        {
            return ImdbContext.CUser.Include(x => x.Ratings).FirstOrDefault(x => x.UserId == id);
        }
        
        public CUser GetSearchHistory(int id)
        {
            return ImdbContext.CUser.Include(x => x.SearchHistories).FirstOrDefault(x => x.UserId == id);
        }
        
        
        public void Rate(int uid, string movieConst, int rating)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from rate({uid}, {movieConst}, {rating})");
        }
        
        public void AddReview(int uid, string movieConst, string review)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from add_review({movieConst}, {uid}, {review})");
        }
        
        public void AddToSearchHistory(int uid, string searchstring)
        {
            ImdbContext.Database.ExecuteSqlInterpolated($"select * from add_to_search_history({uid}, {searchstring})");
        }
        
        public ImdbContext ImdbContext
        {
            get { return Context as ImdbContext; }
        }
    }
}