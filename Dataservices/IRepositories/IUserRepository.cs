namespace Dataservices.IRepositories
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using CRUDRepository;
    using Domain.User;

    public interface IUserRepository : IMutableRepository<CUser>
    {
        public CUser GetReviews(int id);
        public CUser GetRatings(int id);
        public CUser GetSearchHistory(int id);
        public void Rate(int uid, string movieConst, int rating);
        public void AddReview(int uid, string movieConst, string review);
        public void AddToSearchHistory(int uid, string searchstring);
        public void BookmarkPerson(string nConst, int uid, bool alreadyMarked);
        public void BookmarkTitle(string tConst, int uid, bool alreadyMarked);
        public IEnumerable<CBookmarkTitle> GetTitleBookmarksByUser(int id);
        public IEnumerable<CBookmarkPerson> GetPersonBookmarksByUser(int id);
    }
}