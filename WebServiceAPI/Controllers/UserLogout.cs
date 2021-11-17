using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebServiceAPI.Models.UserManagement;

using Dataservices.Domain.User;
using Dataservices.IRepositories;
using WebServiceToken.Services;
using DataServices.Authentication;
using Dataservices;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;

namespace WebServiceAPI.Controllers
{

    [Route("api/v1/user")]
    [ApiController]
    public class UserLogout : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IConfiguration _configuration;

        public UserLogout(IUserRepository userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            LoginRequestModel model = new LoginRequestModel();

            model.UserId = 0;
            model.Username = "";
            model.Password = "";

            var auth = new AuthenticateResponse(_configuration);

            string token = auth.InvalidateJwtToken();

            var processed_info = new
            {
                token = token
            };

            return Ok(JsonConvert.SerializeObject(processed_info));
        }
    }
}
