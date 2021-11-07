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
        
        public List<CReviews> Reviews { get; set; }
        public List<CBookmarkPerson> BookmarkedPersons { get; set; }
        public List<CBookmarkTitle> BookmarkedTitles { get; set; }
        public List<CRatingHistory> Ratings { get; set; }
        public List<CSearchHistory> SearchHistories { get; set; }
    }
}