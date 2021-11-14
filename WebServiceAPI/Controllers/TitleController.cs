using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
//install AutoMapper from nuget
using AutoMapper;
using Dataservices.Domain;
using Dataservices.IRepositories;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using WebServiceAPI.Models;

namespace WebServiceAPI.Controllers
{
    using Dataservices.Domain.Imdb;

    [Route("api/titles")]
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
        
        
        [HttpGet("cast/{id}")]
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

        [HttpGet("crew/{id}")]
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

        [HttpGet(("rating/{id}"))]
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

        [HttpGet("episodes/{id}")]
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
           return _linkGenerator.GetUriByName(HttpContext, nameof(GetCast), new {title.Tconst});
        }
    }
}