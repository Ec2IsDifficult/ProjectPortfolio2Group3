using System.Collections.Generic;
using Dataservices.Domain.User;

namespace WebServiceAPI.Models.UserViews
{
    public class SearchHistoryViewModel
    {
        public string Url { get; set; }
        public IEnumerable<CSearchHistory> SearchHistories { get; set; }
    }

    public class CreateSearchHistoryViewModel
    {
        public IEnumerable<CSearchHistory> SearchHistories { get; set; }
    }
}