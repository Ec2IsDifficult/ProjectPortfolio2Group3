using AutoMapper;
using Dataservices.Domain.User;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Models.UserProfiles
{
    public class BookmarkTitleProfile : Profile
    {
        public BookmarkTitleProfile()
        {
            CreateMap<CBookmarkTitle, BookmarkTitleViewModel>();
            CreateMap<CreateBookmarkTitleViewModel, CBookmarkTitle>();
        }
    }
}