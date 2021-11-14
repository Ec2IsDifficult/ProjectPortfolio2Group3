using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    public class TitlesProfile : Profile
    {
        public TitlesProfile()
        {
            CreateMap<ImdbTitleBasics, TitlesViewModel>();
            CreateMap<CreateTitlesViewModel, ImdbTitleBasics>();
        }
    }
}