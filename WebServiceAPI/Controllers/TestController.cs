using System;
using Microsoft.AspNetCore.Mvc;

using WebServiceAPI.Attributes;

namespace WebServiceAPI.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class TestController : ControllerBase
    {
        [Authorization]
        [HttpGet]
        public IActionResult TestAuth()
        {
            Console.WriteLine("Testing with authorization");
            try
            {
                var user_id = Request.HttpContext.Items["UserId"];
                return Ok($"UserId from token: {user_id}");
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
