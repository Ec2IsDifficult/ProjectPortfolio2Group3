using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    public class CrewProfile : Profile
    {
        public CrewProfile()
        {
            CreateMap<ImdbTitleBasics, CrewViewModel>();
            CreateMap<CreateCrewViewModel, ImdbTitleBasics>();
        }
    }
}