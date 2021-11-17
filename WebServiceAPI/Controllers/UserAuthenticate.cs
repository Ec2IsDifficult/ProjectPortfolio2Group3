using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Dataservices;

using DataServices.Authentication;
using Microsoft.Extensions.Configuration;

namespace WebServiceAPI.Controllers
{

    [ApiController]
    [Route("api/v1/authenticate")]
    public class AuthenticateToken : ControllerBase
    {

        private IConfiguration _config;

        public AuthenticateToken(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost()]
        public IActionResult Authenticate()
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_config);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0)
            {
                HttpContext.Items["user"] = user_id;
                return Ok($"Validated for user {user_id}");
            }

            return Unauthorized("Invalid token");
        }

    }
}
