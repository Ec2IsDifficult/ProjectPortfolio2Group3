using AutoMapper;
using Dataservices.Domain;

namespace WebServiceAPI.Models.Profiles
{
    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<ImdbTitleBasics, CastViewModel>();
            CreateMap<CreateCastViewModel, ImdbTitleBasics>();
        }
    }
}