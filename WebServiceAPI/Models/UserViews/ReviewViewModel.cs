using System.Collections.Generic;
using Dataservices.Domain.User;

namespace WebServiceAPI.Models.UserViews
{
    public class ReviewViewModel
    {
        public string Url { get; set; }
        public IEnumerable<CReviews> Reviews { get; set; }
    }

    public class CreateReviewViewModel
    {
        public IEnumerable<CReviews> Reviews { get; set; }
    }
}