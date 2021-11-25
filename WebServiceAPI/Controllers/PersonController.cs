using System.Linq;
using AutoMapper;
using Dataservices.Domain;
using Dataservices.Domain.FunctionObjects;
using Dataservices.IRepositories;
using Dataservices.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebServiceAPI.Models.PersonViews;

namespace WebServiceAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : Controller
    {
        //we need the IRepository here for dependency injection
        private readonly IPersonRepository _personService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;
        
        public PersonController(IPersonRepository personService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _personService = personService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var actors = _personService.GetAll();
            if (actors == null)
            {
                return NotFound();
            }

            var model = actors.Select(CreateNameBasicsViewModel);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var actors = _personService.Get(id);
            if (actors == null)
            {
                return NotFound();
            }

            var model = CreateNameBasicsViewModel(actors);
            return Ok(model);
        }
        [HttpGet("{id}/knownfor")]
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

        [HttpGet("{name}/coactors")]
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