using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AutoMapper.Internal;
using Dataservices.Domain.FunctionObjects;
using Dataservices.IRepositories;
using Dataservices.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using WebServiceAPI.Models;

namespace WebServiceAPI.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Dataservices.Domain;
    using Dataservices.Domain.Imdb;
    using WebServiceToken.Services;

    [Route("api/v1/titles")]
    [ApiController]
    public class TitleController : Controller
    {
        private readonly ITitleRepository _titleService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;

        public TitleController(ITitleRepository titleService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _titleService = titleService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        
        [HttpGet(Name = nameof(GetAll))]
        public IActionResult GetAll()
        {
            var titles = _titleService.GetAll();
            if (titles == null)
            {
                return NotFound();
            }

            var model = new Collection<TitlesViewModel>();
            foreach(var title in titles)
                model.Add(CreateTitlesViewModel(nameof(GetAll), title));
            return Ok(model);
        }

        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _titleService.Get(id);
            if (title == null)
            {
                return NotFound();
            }
            var model = CreateTitlesViewModel(nameof(GetTitle), title);
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
            var model = CreateCastViewModel(nameof(GetCast), cast);
            return Ok(model);
        }

        [HttpGet("{id}/crew", Name = nameof(GetCrew))]
        public IActionResult GetCrew(string id)
        {
            var crew = _titleService.GetCrew(id);
            if (crew == null)
            {
                return NotFound();
            }

            var model = CreateCrewViewModel(nameof(GetCrew), crew);
            return Ok(model);
        }

        [HttpGet("{id}/rating", Name = nameof(GetRating))]
        public IActionResult GetRating(string id)
        {
            var rating = _titleService.GetRating(id);
            if (rating == null)
            {
                return NotFound();
            }
            
            var model = CreateRatingViewModel(nameof(GetRating), rating);
            return Ok(model);
        }

        [HttpGet("{id}/episodes", Name = nameof(GetEpisodes))]
        public IActionResult GetEpisodes(string id)
        {
            var episodes = _titleService.GetEpisodes(id);
            if (episodes == null)
            {
                return NotFound();
            }

            var model = CreateEpisodeViewModel(nameof(GetEpisodes), episodes);
            return Ok(model);
        }

        [HttpGet("year/{year}", Name = nameof(GetTitlesByYear))]
        public IActionResult GetTitlesByYear(int year, [FromQuery] PaginationQuery paginationQuery)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);
            var titles = _titleService.GetTitlesByYear(year, paginationFilter);
            if (titles == null)
            {
                return NotFound("No titles for this year available");
            }
            
            var data = _mapper.Map<List<TitlesViewModel>>(titles);
            foreach(var title in data)
                title.Url = HttpContext.Request.GetDisplayUrl();
            
            var url = $"http://localhost:5000/api/v1/titles/year/{year}";
            UriService uriService = new UriService(url);
            
            var totalLength = _titleService.GetTitlesByYear(year, null);
            
            var paginationResponse = PaginationHelper.CreatePagenatedResponse(uriService, paginationFilter, data, totalLength.Count());
            return Ok(paginationResponse);
        }

        [HttpGet("between/{year1}/{year2}", Name = nameof(GetTitlesBetween))]
        public IActionResult GetTitlesBetween(int year1, int year2)
        {
            var titles = _titleService.GetTitlesBetween(year1, year2);
            if (titles == null)
            {
                return NotFound("No titles between these years available");
            }
            
            var model = new Collection<TitlesViewModel>();
            foreach(var title in titles)
                model.Add(CreateTitlesViewModel(nameof(GetTitlesBetween), title));
            return Ok(model);
        }
        
        [HttpGet("random/{amount}/{lowestRating}", Name = nameof(GetRandomTitles))]
        public IActionResult GetRandomTitles(int amount, float lowestRating)
        {
            var titles = _titleService.GetRandomTitles(amount, lowestRating);
            Collection<TitlesViewModel> model = new Collection<TitlesViewModel>();
            foreach(var title in titles)
                model.Add(CreateTitlesViewModel(nameof(GetTitlesBetween), title));
            return Ok(model);
        }

        [HttpGet("{name}/genre", Name = nameof(GetMoviesByGenre))]
        public IActionResult GetMoviesByGenre(string name, [FromQuery] PaginationQuery paginationQuery)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery) ;
            var movies = _titleService.GetMoviesByGenre(name, paginationFilter);
            if (movies == null)
            {
                return NotFound();
            }
            
            var data = _mapper.Map<List<GenreViewModel>>(movies);
            foreach(var title in data)
                title.Url = HttpContext.Request.GetDisplayUrl();
            
            var url = $"http://localhost:5000/api/v1/titles/{name}/genre";
            UriService uriService = new UriService(url);
            
            var paginationResponse = PaginationHelper.CreatePagenatedResponse(uriService, paginationFilter, data,0);
            return Ok(paginationResponse);
        }
        

        [HttpGet("searchPhrase={searchPhrase}")]
        public IActionResult SearchBestMatch(string searchPhrase)
        {
            var searchResults = _titleService.SearchBestMatch(searchPhrase.Split());
            if (searchResults == null) 
                return NotFound();

            Collection<SearchResultViewModel> model = new Collection<SearchResultViewModel>();
            foreach(var result in searchResults)
                model.Add(CreateSearchResultViewModel(nameof(SearchBestMatch), result));
            return Ok(model);
        }
        
        [HttpGet("genres")]
        public IActionResult GetAllGenres([FromQuery] PaginationQuery paginationQuery)
        {
            //Mapping the the object from the GET query to a pagination-filter object with page-number and page-size
            //If the object has no page-number or size the default constructor will give it values
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery) ;
            
            //getting all the objects from the database
            var allGenres = _titleService.GetAllGenres(paginationFilter);

            //Mapping the all-genres enumerable to a list of view models
            var data = _mapper.Map<List<AllGenresViewModel>>(allGenres);
            
            //Creating the specific base url for the path, and setting it to the created object below
            var url = "http://localhost:5000/api/v1/titles/genres";
            UriService uriService = new UriService(url);
            
            //
            var paginationResponse = PaginationHelper.CreatePagenatedResponse(uriService, paginationFilter, data, _titleService.NumberOfGenres());
            return Ok(paginationResponse);
        }
        
        /*public PagedResponse<AllGenresViewModel> CreateAllGenresViewModel(string name, IEnumerable<Genres> genre)
        {
            var model = new PagedResponse<AllGenresViewModel>(_mapper.Map<List<AllGenresViewModel>>(genre));
            foreach (var mod in model.Data)
            {
                mod.Url = HttpContext.Request.GetDisplayUrl();
            }
            return model;
        }*/

        public SearchResultViewModel CreateSearchResultViewModel(string name, BestMatchSearch search)
        {
            var model = _mapper.Map<SearchResultViewModel>(search);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
        
        public GenreViewModel CreateGenreViewModel(string name, MoviesByGenre titles)
        {
            var model = _mapper.Map<GenreViewModel>(titles);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
        
        public TitlesViewModel CreateTitlesViewModel(string name, ImdbTitleBasics titles)
        {
            var model = _mapper.Map<TitlesViewModel>(titles);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
        
        public EpisodeViewModel CreateEpisodeViewModel(string name, ImdbTitleBasics title)
        {
            var model = _mapper.Map<EpisodeViewModel>(title);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
        
        public RatingViewModel CreateRatingViewModel(string name, ImdbTitleRatings title)
        {
            var model = _mapper.Map<RatingViewModel>(title);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }

        public CrewViewModel CreateCrewViewModel(string name, ImdbTitleBasics title)
        {
            var model = _mapper.Map<CrewViewModel>(title);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }

        public CastViewModel CreateCastViewModel(string name, ImdbTitleBasics title)
        {
            var model = _mapper.Map<CastViewModel>(title);
            model.Url = HttpContext.Request.GetDisplayUrl();
            return model;
        }
    }
}


/*if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
{           
    Collection<PagedResponse<AllGenresViewModel>> model = new Collection<PagedResponse<AllGenresViewModel>>();
    model.Add(CreateAllGenresViewModel(nameof(GetAllGenres), allGenres));
    return Ok(model);
}*/