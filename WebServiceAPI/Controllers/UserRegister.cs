using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebServiceAPI.Models.UserManagement;

using Dataservices.Domain.User;
using Dataservices.IRepositories;
using WebServiceToken.Services;

namespace WebServiceAPI.Controllers
{

    [Route("api/v1/user")]
    [ApiController]
    public class UserRegister : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IConfiguration _configuration;

        public UserRegister(IUserRepository userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(UserInformation userInformation)
        {
            /*
             * Check if username already exist in the database
             */
            if (_userService.GetUser(userInformation.Username) != null)
            {
                return BadRequest("Username already exist.");
            }

            /*
             * Execute the interface to create user
             */
            try
            {
                _userService.CreateUser(userInformation.Username, userInformation.Email, userInformation.Password);
                return Ok();

            } catch
            {
                return BadRequest("Failed to register.");
            }
        }
    }
}
