using System.Collections.Generic;
using Dataservices.Domain;

namespace WebServiceAPI.Models
{
    public class CrewViewModel
    {
        public string Url { get; set; }
        public string PrimaryTitle { get; set; }
        public IList<ImdbCrew> Crew { get; set; }
    }

    public class CreateCrewViewModel
    {
        public string PrimaryTitle { get; set; }
        public IList<ImdbCrew> Crew { get; set; }
    }
}