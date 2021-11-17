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
    [Route("api/v1/login")]
    public class UserLogin : ControllerBase
    {

        private IConfiguration _config;

        public UserLogin(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost()]
        public IActionResult Login(LoginRequestModel model)
        {
            var username = model.Username;
            var password = model.Password;

            bool user_ok = false;

            if (username == null)
                return Unauthorized("Username not provided");

            if (password == null)
                return Unauthorized("Password not provided");

            var ctx = new ImdbContext(_config);
            var user_found = ctx.CUser.Where(x => x.UserName == username);
            var found = user_found.ToList();

            if (found.Count() > 0)
            {
                if (password == found.First().Password)
                {
                    model.UserId = found.First().UserId;
                    user_ok = true;
                }
            }

            if (user_ok == false)
                return Unauthorized("Login incorrect");

            var auth = new AuthenticateResponse(_config);

            string token = auth.GenerateJwtToken(model);

            var processed_info = new
            {
                token = token
            };

            return Ok(JsonConvert.SerializeObject(processed_info));
        }

    }

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
