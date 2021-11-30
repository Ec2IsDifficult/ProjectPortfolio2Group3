using System;
using System.Linq;
using AutoMapper;
using Dataservices.Domain.User;
using Dataservices.IRepositories;
using Dataservices.Repository;
using DataServices.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using WebServiceAPI.Attributes;
using WebServiceAPI.Models.UserViews;

namespace WebServiceAPI.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : Controller
    {
        //we need the IRepository here for dependency injection
        private readonly IUserRepository _userService;
        private readonly IConfiguration _configuration;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userService, IConfiguration configuration, LinkGenerator linkGenerator, IMapper mapper)
        {
            _userService = userService;
            _configuration = configuration;
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
        [Authorization]
        [HttpGet("reviews")]
        public IActionResult GetReviews()
        {

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_configuration);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0 && user_id != "0")
            {
                try
                {
                    var reviews = _userService.GetReviews(Int32.Parse(user_id));
                    if (reviews == null)
                    {
                        return NotFound("No reviews available.");
                    }

                    var model = CreateReviewViewModel(reviews);
                    return Ok(model);

                }
                catch
                {
                    return BadRequest("Failed to get review.");
                }
            }

            return NotFound("No reviews available.");
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
        [Authorization]
        [HttpGet("searchhistory")]
        public IActionResult GetSearchHistory()
        {
            //var history = _userService.GetSearchHistory(id);
            //if (history == null)
            //{
            //    return NotFound("no previous searches");
            //}

            //var model = CreateSearchHistoryViewModel(history);
            //return Ok(model);

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_configuration);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0 && user_id != "0")
            {
                try
                {
                    var history = _userService.GetSearchHistory(Int32.Parse(user_id));
                    if (history == null)
                    {
                        return NotFound("no previous searches");
                    }

                    var model = CreateSearchHistoryViewModel(history);
                    return Ok(model);
                }
                catch
                {
                    return BadRequest("Failed to update rating.");
                }
            }

            return BadRequest("No user information found from the token.");
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

        [Authorization]
        [HttpPost("rate")]
        public IActionResult RateMovie([FromBody] CRatingHistory rating)
        {

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_configuration);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0 && user_id != "0")
            {
                try
                {
                    _userService.Rate(Int32.Parse(user_id), rating.Tconst, rating.Rating);
                    return Created("Success", rating);
                }
                catch
                {
                    return BadRequest("Failed to update rating.");
                }
            }

            return BadRequest("No user information found from the token.");
        }

        [Authorization]
        [HttpPost("review")]
        public IActionResult AddReview([FromBody] CReviews review)
        {
            //var model = _mapper.Map<CReviews>(review);
            //_userService.AddReview(review.UserId, review.Tconst, review.Review);
            //return Created("Success", review);

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_configuration);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0 && user_id != "0")
            {
                try
                {
                    _userService.AddReview(Int32.Parse(user_id), review.Tconst, review.Review);
                    return Created("Success", review);
                }
                catch
                {
                    return BadRequest("Failed to add/update review.");
                }
            }

            return BadRequest("No user information found from the token.");
        }

        [Authorization]
        [HttpPost("search")]
        public IActionResult AddToSearchHistory([FromBody] CSearchHistory search)
        {
            //_userService.AddToSearchHistory(search.UserId, search.SearchPhrase);
            //return Created("success", search);

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_configuration);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0 && user_id != "0")
            {
                try
                {
                    _userService.AddToSearchHistory(Int32.Parse(user_id), search.SearchPhrase);
                    return Created("Success", search);
                }
                catch
                {
                    return BadRequest("Failed to update search.");
                }
            }

            return BadRequest("No user information found from the token.");
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
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }

        public UserViewModel CreateUserViewModel(CUser user)
        {
            var model = _mapper.Map<UserViewModel>(user);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }

        public BookmarkTitleViewModel CreateBookmarkTitleViewModel(CBookmarkTitle title)
        {
            var model = _mapper.Map<BookmarkTitleViewModel>(title);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }

        public SearchHistoryViewModel CreateSearchHistoryViewModel(CUser history)
        {
            var model = _mapper.Map<SearchHistoryViewModel>(history);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }

        public RatingViewModel CreateRatingViewModel(CUser ratings)
        {
            var model = _mapper.Map<RatingViewModel>(ratings);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
        public ReviewViewModel CreateReviewViewModel(CUser reviews)
        {
            var model = _mapper.Map<ReviewViewModel>(reviews);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
    }
}
