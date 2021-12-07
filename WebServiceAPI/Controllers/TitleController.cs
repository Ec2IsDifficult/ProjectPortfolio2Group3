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
        public IActionResult GetTitlesByYear(int year)
        {
            var titles = _titleService.GetTitlesByYear(year);
            if (titles == null)
            {
                return NotFound("No titles for this year available");
            }

            var model = new Collection<TitlesViewModel>();
            foreach(var title in titles)
                model.Add(CreateTitlesViewModel(nameof(GetTitlesByYear), title));
            return Ok(model);
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
        
        /*
        [HttpGet("adult", Name = nameof(GetAdultMovies))]
        public IActionResult GetAdultMovies()
        {
            var movies = _titleService.GetAdultMovies();
            if (movies == null)
            {
                return NotFound();
            }

            var model = new Collection<TitlesViewModel>();
            foreach(var title in movies)
                model.Add(CreateTitlesViewModel(nameof(GetAdultMovies), title));
            return Ok(model);
        }*/
        
        [HttpGet("{id}/genre", Name = nameof(GetMoviesByGenre))]
        public IActionResult GetMoviesByGenre(string name)
        {
            var movies = _titleService.GetMoviesSimilarGenre(name);
            if (movies == null)
            {
                return NotFound();
            }

            var model = new Collection<GenreViewModel>();
            foreach(var title in movies)
                model.Add(CreateGenreViewModel(title));
            return Ok(model);
        }
        
        public GenreViewModel CreateGenreViewModel(MoviesByGenre titles)
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