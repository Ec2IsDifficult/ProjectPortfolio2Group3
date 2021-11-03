using System.ComponentModel.DataAnnotations;

namespace Dataservices.Domain.User
{
    public class CSearchHistory
    {
        public int UserId{ get; set; }
        public string SearchPhrase { get; set; }
        public TimestampAttribute SearchHistoryTimeStamp { get; set; }

        public CUser User {get; set;}
    }
}