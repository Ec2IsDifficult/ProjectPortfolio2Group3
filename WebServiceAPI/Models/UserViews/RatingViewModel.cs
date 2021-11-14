using System.Collections.Generic;
using Dataservices.Domain.User;

namespace WebServiceAPI.Models.UserViews
{
    public class RatingViewModel
    {
        public string Url { get; set; }
        public IEnumerable<CRatingHistory> Ratings { get; set; }
    }

    public class CreateRatingViewModel
    {
        public IEnumerable<CRatingHistory> Ratings { get; set; }
    }
}