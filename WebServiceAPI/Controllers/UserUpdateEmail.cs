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
    public class UserUpdateEmail : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IConfiguration _configuration;

        public UserUpdateEmail(IUserRepository userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("email")]
        public IActionResult UpdateEmail(UserInformation userInformation)
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
                 * Execute the interface to update email address
                 */
                try
                {
                    _userService.UserUpdateEmail(int.Parse(user_id), userInformation.Email);
                    return Ok();

                }
                catch
                {
                    return BadRequest("Failed to update the email address.");
                }
            }

            return BadRequest("No user information found from the token.");

        }
    }
}
