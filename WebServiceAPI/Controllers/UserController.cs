using System.Linq;
using AutoMapper;
using Dataservices.Domain.User;
using Dataservices.IRepositories;
using Dataservices.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        //we need the IRepository here for dependency injection
        private readonly IUserRepository _userService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _userService = userService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = CreateUserViewModel(user);
            return Ok(model);
        }
            //object cycle
        [HttpGet("{id}/reviews")]
        public IActionResult GetReviews(int id)
        {
            var reviews = _userService.GetReviews(id);
            if (reviews == null)
            {
                return NotFound("No reviews available");
            }

            var model = CreateReviewViewModel(reviews);
            return Ok(model);
        }

        //SOMETHING WRONG WITH THE MAPPING
        [HttpGet("{id}/ratings")]
        public IActionResult GetRatings(int id)
        {
            var ratings = _userService.GetRatings(id);
            if (ratings == null)
            {
                return NotFound();
            }

            var model = CreateRatingViewModel(ratings);
            return Ok(model);
        }

            //object cycle
        [HttpGet("{id}/searchhistory")]
        public IActionResult GetSearchHistory(int id)
        {
            var history = _userService.GetSearchHistory(id);
            if (history == null)
            {
                return NotFound("no previous searches");
            }

            var model = CreateSearchHistoryViewModel(history);
            return Ok(model);
        }

        [HttpGet("{id}/bookmarks/titles")]
        public IActionResult GetTitleBookmarksByUser(int id)
        {
            var marks = _userService.GetTitleBookmarksByUser(id);
            if (marks == null)
            {
                return NotFound();
            }

            var model = marks.Select(CreateBookmarkTitleViewModel);
            return Ok(model);
        }

        //in user controller
        [HttpGet("{id}/bookmarks/person")]
        public IActionResult GetPersonBookmarksByUser(int id)
        {
            var persons = _userService.GetPersonBookmarksByUser(id);
            if (persons == null)
            {
                return NotFound();
            }

            var model = persons.Select(CreateBookmarkPersonViewModel);
            return Ok(model);
        }

        
        [HttpPost("rate")]
        public IActionResult RateMovie([FromBody] CRatingHistory rating)
        {
            
            //var rating = _mapper.Map<CRatingHistory>(model);
            _userService.Rate(rating.UserId, rating.Tconst, rating.Rating);
            return Created("Success",rating);
        }

        [HttpPost("review")]
        public IActionResult AddReview([FromBody] CReviews review)
        {
            //var model = _mapper.Map<CReviews>(review);
            _userService.AddReview(review.UserId, review.Tconst, review.Review);
            return Created("Success", review);
        }

        [HttpPost("search")]
        public IActionResult AddToSearchHistory([FromBody] CSearchHistory search)
        {
            _userService.AddToSearchHistory(search.UserId, search.SearchPhrase);
            return Created("success", search);
        }

        [HttpPost("bookmark/person")]
        public IActionResult BookmarkPerson([FromBody] CBookmarkPerson person)
        {
            _userService.BookmarkPerson(person.Nconst, person.UserId, false);
            return Created("Success", person);
        }

        [HttpPost("bookmark/title")]
        public IActionResult BookmarkTitle([FromBody] CBookmarkTitle title)
        {
            _userService.BookmarkTitle(title.Tconst, title.UserId, false);
            return Created("Success", title);
        }
        
        public BookmarkPersonViewModel CreateBookmarkPersonViewModel(CBookmarkPerson person)
        {
            var model = _mapper.Map<BookmarkPersonViewModel>(person);
            return model;
        }
        
        public UserViewModel CreateUserViewModel(CUser user)
        {
            var model = _mapper.Map<UserViewModel>(user);
            return model;
        }

        public BookmarkTitleViewModel CreateBookmarkTitleViewModel(CBookmarkTitle title)
        {
            var model = _mapper.Map<BookmarkTitleViewModel>(title);
            return model;
        }

        public SearchHistoryViewModel CreateSearchHistoryViewModel(CUser history)
        {
            var model = _mapper.Map<SearchHistoryViewModel>(history);
            return model;
        }

        public RatingViewModel CreateRatingViewModel(CUser ratings)
        {
            var model = _mapper.Map<RatingViewModel>(ratings);
            return model;
        }
        public ReviewViewModel CreateReviewViewModel(CUser reviews)
        {
            var model = _mapper.Map<ReviewViewModel>(reviews);
            //model.Url = GetUrl(titles);

            return model;
        }
    }
}
    