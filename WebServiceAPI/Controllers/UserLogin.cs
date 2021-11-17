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
    public class UserLogin : ControllerBase
    {
        private readonly IUserRepository _userService;
        private readonly IConfiguration _configuration;

        public UserLogin(IUserRepository userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestModel model)
        {
            var username = model.Username;
            var password = model.Password;

            bool user_ok = false;

            if (username == null)
                return Unauthorized("Username not provided");

            if (password == null)
                return Unauthorized("Password not provided");

            /*
             * Check if username is in the database
             */
            CUser getUserInfo = _userService.GetUser(model.Username);
            if (getUserInfo != null)
            {
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string hashed_password = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

                /*
                 * Testing for username: ruc1, password: ruc
                 */
                //Console.WriteLine($"Hashed   : {hashed_password}");
                //Console.WriteLine($"Expected : 21d0e26d0b99b0d483771d5426e8c5aa");

                if (hashed_password == getUserInfo.Password)
                {
                    model.UserId = getUserInfo.UserId;
                    user_ok = true;
                }

            }

            if (user_ok == false)
                return Unauthorized("Login incorrect");

            var auth = new AuthenticateResponse(_configuration);

            string token = auth.GenerateJwtToken(model);

            var processed_info = new
            {
                token = token
            };

            return Ok(JsonConvert.SerializeObject(processed_info));
        }
    }
}
