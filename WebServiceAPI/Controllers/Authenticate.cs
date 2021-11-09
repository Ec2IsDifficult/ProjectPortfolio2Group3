using System;
using System.Linq;
using Dataservices;
using Microsoft.AspNetCore.Mvc;
using WebServiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Dataservices.Domain.User;

namespace WebServiceAPI.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class MoviesController : ControllerBase
    {

        [HttpGet()]
        public IActionResult Login(HttpContext context)
        {
            var username = (CUser)context.Items["username"];
            //var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            return BadRequest(new { message = $"Username {username} or password is incorrect" });
        }
    }
}
