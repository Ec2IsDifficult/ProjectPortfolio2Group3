using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dataservices.Domain;
using Dataservices.Domain.FunctionObjects;
using Dataservices.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using WebServiceAPI.Models.PersonViews;

namespace WebServiceAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        
        public PersonController(IPersonRepository personService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _personService = personService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("knownfor/{id}")]
        //works but all viewed values are null
        public IActionResult GetKnownFor(string id)
        {
            var actors = _personService.GetKnowFor(id);
            if (actors == null)
            {
                return NotFound();
            }

            var model = actors.Select(CreateKnownForViewModel);
            return Ok(model);
        }

        [HttpGet("coactors/{name}")]
        public IActionResult CoActors(string name)
        {
            var actors = _personService.CoActors(name);
            if (actors == null)
            {
                return NotFound();
            }

            var model = actors.Select(CreateCoActorsViewModel);
            return Ok(model);
        }

        [HttpGet("year/{year}")]
        public IActionResult GetPersonByYear(int year)
        {
            var actors = _personService.GetPersonsByYear(year);
            if (actors == null)
            {
                return NotFound("No Actors from this year");
            }

            var model = actors.Select(CreateNameBasicsViewModel);
            return Ok(model);
        }

        public NameBasicsViewModel CreateNameBasicsViewModel(ImdbNameBasics actors)
        {
            var model = _mapper.Map<NameBasicsViewModel>(actors);
            //model.Url = GetUrl(titles);
            return model;
        }
        public CoActorsViewModel CreateCoActorsViewModel(CoActors actor)
        {
            var model = _mapper.Map<CoActorsViewModel>(actor);
            //model.Url = GetUrl(titles);
            return model;
        }

        public KnownForViewModel CreateKnownForViewModel(ImdbKnownFor actors)
        {
            var model = _mapper.Map<KnownForViewModel>(actors);
            //model.Url = GetUrl(titles);
            return model;
        }
    }
}