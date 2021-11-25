using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Dataservices.Domain.FunctionObjects;
using Dataservices.IRepositories;
using Dataservices.Repository;
using Microsoft.AspNetCore.Routing;
using WebServiceAPI.Models;

namespace WebServiceAPI.Controllers
{
    using Dataservices.Domain.Imdb;

    [Route("api/titles")]
    [ApiController]
    public class TitleController : Controller
    {
        //we need the IRepository here because of Dependency Injection
        private readonly ITitleRepository _titleService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        
        public TitleController(ITitleRepository titleService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _titleService = titleService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var titles = _titleService.GetAll();
            if (titles == null)
            {
                return NotFound();
            }
            var model = titles.Select(CreateTitlesViewModel);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var title = _titleService.Get(id);
            if (title == null)
            {
                return NotFound();
            }
            var model = CreateCastViewModel(title);
            return Ok(model);
        }
        
        [HttpGet("{id}/cast", Name = nameof(GetCast))]
        public IActionResult GetCast(string id)
        {
            var cast = _titleService.GetCast(id);
            if (cast == null)
            {
                return NotFound();
            }
            var model = CreateCastViewModel(cast);
            return Ok(model);
        }

        [HttpGet("{id}/crew")]
        public IActionResult GetCrew(string id)
        {
            var crew = _titleService.GetCrew(id);
            if (crew == null)
            {
                return NotFound();
            }

            var model = CreateCrewViewModel(crew);
            return Ok(model);
        }

        [HttpGet(("{id}/rating"))]
        public IActionResult GetRating(string id)
        {
            var rating = _titleService.GetRating(id);
            if (rating == null)
            {
                return NotFound();
            }

            var model = CreateRatingViewModel(rating);
            return Ok(model);
        }

        [HttpGet("{id}/episodes")]
        public IActionResult GetEpisodes(string id)
        {
            var episodes = _titleService.GetEpisodes(id);
            if (episodes == null)
            {
                return NotFound();
            }

            var model = CreateEpisodeViewModel(episodes);
            return Ok(model);
        }

        [HttpGet("year/{year}")]
        public IActionResult GetTitlesByYear(int year)
        {
            var titles = _titleService.GetTitlesByYear(year);
            if (titles == null)
            {
                return NotFound("No titles for this year available");
            }

            var model = titles.Select(CreateTitlesViewModel);
            return Ok(model);
        }

        [HttpGet("between/{year1}/{year2}")]
        public IActionResult GetTitlesBetween(int year1, int year2)
        {
            var titles = _titleService.GetTitlesBetween(year1, year2);
            if (titles == null)
            {
                return NotFound("No titles between these years available");
            }

            var model = titles.Select(CreateTitlesViewModel);
            return Ok(model);
        }

        [HttpGet("adult")]
        public IActionResult GetAdultMovies()
        {
            var movies = _titleService.GetAdultMovies();
            if (movies == null)
            {
                return NotFound();
            }

            var model = movies.Select(CreateTitlesViewModel);
            return Ok(model);
        }

        [HttpGet("{id}/genre")]
        public IActionResult GetMoviesByGenre(string id)
        {
            var movies = _titleService.GetMoviesByGenre(id);
            if (movies == null)
            {
                return NotFound();
            }

            var model = movies.Select(CreateGenreViewModel);
            return Ok(model);
        }
        
        public GenreViewModel CreateGenreViewModel(MoviesByGenre titles)
        {
            var model = _mapper.Map<GenreViewModel>(titles);
            //model.Url = GetUrl(titles);

            return model;
        }
        
        public TitlesViewModel CreateTitlesViewModel(ImdbTitleBasics titles)
        {
            var model = _mapper.Map<TitlesViewModel>(titles);
            //model.Url = GetUrl(titles);

            return model;
        }


        public EpisodeViewModel CreateEpisodeViewModel(ImdbTitleBasics title)
        {
            var model = _mapper.Map<EpisodeViewModel>(title);
            //model.Url = GetUrl(title);
            return model;
        }
        public RatingViewModel CreateRatingViewModel(ImdbTitleRatings title)
        {
            var model = _mapper.Map<RatingViewModel>(title);
            //model.Url = GetUrl(title);
            return model;
        }

        public CrewViewModel CreateCrewViewModel(ImdbTitleBasics title)
        {
            var model = _mapper.Map<CrewViewModel>(title);
            model.Url = GetUrl(title);
            return model;
        }

        public CastViewModel CreateCastViewModel(ImdbTitleBasics title)
        {
            var model = _mapper.Map<CastViewModel>(title);
            model.Url = GetUrl(title);
            return model;
        }

        private string GetUrl(ImdbTitleBasics title)
        {
           return _linkGenerator.GetUriByName(HttpContext, "cast", 1);
        }
    }
}