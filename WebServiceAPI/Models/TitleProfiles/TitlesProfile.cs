using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    using Dataservices.Domain.Imdb;

    public class TitlesProfile : Profile
    {
        public TitlesProfile()
        {
            CreateMap<ImdbTitleBasics, TitlesViewModel>();
            CreateMap<CreateTitlesViewModel, ImdbTitleBasics>();
        }
    }
}