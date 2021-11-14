using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    using Dataservices.Domain.Imdb;

    public class CrewProfile : Profile
    {
        public CrewProfile()
        {
            CreateMap<ImdbTitleBasics, CrewViewModel>();
            CreateMap<CreateCrewViewModel, ImdbTitleBasics>();
        }
    }
}