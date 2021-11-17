using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

using WebServiceAPI.Attributes;
using WebServiceAPI.Models.UserManagement;
using Dataservices.IRepositories;
using DataServices.Authentication;

namespace WebServiceAPI.Controllers
{
    [Authorization]
    [Route("api/v1/user")]
    [ApiController]
    public class UserUpdatePassword : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IConfiguration _configuration;

        public UserUpdatePassword(IUserRepository userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("password")]
        public IActionResult UpdatePassword(UserInformation userInformation)
        {
            /*
             * Get the UserId from token
             */

            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

            var auth = new AuthenticateResponse(_configuration);

            string user_id = auth.AuthenticateJwtToken(token);

            if (user_id.Length > 0 && user_id != "0")
            {
                /*
             * Execute the interface to update password
             */
                try
                {
                    _userService.SetNewPassword(int.Parse(user_id), userInformation.Password);
                    return Ok();

                }
                catch
                {
                    return BadRequest("Failed to set new password.");
                }
            }

            return BadRequest("No user information found from the token.");

        }
    }
}
