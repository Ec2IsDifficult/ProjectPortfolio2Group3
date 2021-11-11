using System.Collections.Generic;

namespace Dataservices.Domain.User
{
    using System.ComponentModel.DataAnnotations;

    public class CUser
    {
        [Key]
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public IEnumerable<CReviews> Reviews { get; set; }
        public IEnumerable<CBookmarkPerson> BookmarkedPersons { get; set; }
        public IEnumerable<CBookmarkTitle> BookmarkedTitles { get; set; }
        public IEnumerable<CRatingHistory> Ratings { get; set; }
        public IEnumerable<CSearchHistory> SearchHistories { get; set; }
    }
}