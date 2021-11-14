using AutoMapper;
using Dataservices.Domain;
using WebServiceAPI.Models.PersonViews;

namespace WebServiceAPI.Models.PersonProfiles
{
    public class NameBasicsProfile : Profile
    {
        public NameBasicsProfile()
        {
            CreateMap<ImdbNameBasics, NameBasicsViewModel>();
            CreateMap<CreateNameBasicsViewModel, ImdbNameBasics>();
        }
    }
}