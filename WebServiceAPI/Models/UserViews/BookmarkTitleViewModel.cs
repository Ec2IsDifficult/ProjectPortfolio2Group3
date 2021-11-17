using Dataservices.Domain;
using Microsoft.AspNetCore.Routing.Matching;

namespace WebServiceAPI.Models.UserViews
{
    using Dataservices.Domain.Imdb;

    public class BookmarkTitleViewModel
    {
        public string Url { get; set; }
        public ImdbTitleBasics Title { get; set; }
        public int UserId { get; set; }
    }

    public class CreateBookmarkTitleViewModel
    {
        public ImdbTitleBasics Title { get; set; }
        public int UserId { get; set; }
    }
}