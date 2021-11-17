using AutoMapper;
using Dataservices.Domain.User;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Models.UserProfiles
{
    public class BookmarkPersonProfile : Profile
    {
        public BookmarkPersonProfile()
        {
            CreateMap<CBookmarkPerson, BookmarkPersonViewModel>();
            CreateMap<CreateBookmarkPersonViewModel, CBookmarkPerson>();
        }
    }
}