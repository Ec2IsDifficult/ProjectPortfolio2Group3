using AutoMapper;
using Dataservices.Domain.FunctionObjects;
using WebServiceAPI.Models.PersonViews;

namespace WebServiceAPI.Models.PersonProfiles
{
    public class CoActorsProfile : Profile
    {
        public CoActorsProfile()
        {
            CreateMap<CoActors, CoActorsViewModel>();
            CreateMap<CreateCoActorsViewModel, CoActors>();
        }
    }
}