using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using DataServices.Authentication;

namespace WebServiceAPI.Middleware
{

    public static class AuthorizationMiddlewareExtension
    {
        public static IApplicationBuilder UseJwtAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }

    public class AuthorizationMiddleware
    {

        private readonly RequestDelegate _nextDelegate;
        private readonly IConfiguration _config;

        public AuthorizationMiddleware(RequestDelegate nextDelegate, IConfiguration config)
        {
            _nextDelegate = nextDelegate;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last().ToString();

                var auth = new AuthenticateResponse(_config);

                string user_id = auth.AuthenticateJwtToken(token);

                if (user_id.Length > 0)
                {
                    context.Items["UserId"] = user_id;
                }
            }
            catch { Console.WriteLine("Middleware error"); }

            await _nextDelegate(context);
        }
    }
}
