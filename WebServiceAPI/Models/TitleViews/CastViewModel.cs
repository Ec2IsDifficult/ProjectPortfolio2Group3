using System.Collections.Generic;
using Dataservices.Domain;

namespace WebServiceAPI.Models
{
    public class CastViewModel
    {
        public string Url { get; set; }
        public string PrimaryTitle { get; set; }
        public IList<ImdbCast> Cast { get; set; }
    }

    public class CreateCastViewModel
    {
        public string PrimaryTitle { get; set; }
        public IList<ImdbCast> Cast { get; set; }
    }
}