using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    using Dataservices.Domain.Imdb;

    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<ImdbTitleBasics, CastViewModel>();
            CreateMap<CreateCastViewModel, ImdbTitleBasics>();
        }
    }
}