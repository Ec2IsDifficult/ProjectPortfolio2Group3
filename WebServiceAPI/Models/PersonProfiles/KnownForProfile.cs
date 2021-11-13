using AutoMapper;
using Dataservices.Domain;
using WebServiceAPI.Models.PersonViews;

namespace WebServiceAPI.Models.PersonProfiles
{
    public class KnownForProfile : Profile
    {
        public KnownForProfile()
        {
            CreateMap<ImdbKnownFor, KnownForViewModel>();
            CreateMap<CreateKnownForViewModel, ImdbKnownFor>();
        }
    }
}