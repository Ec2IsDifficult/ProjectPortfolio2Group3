using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DataServices.Authentication
{
    public class AuthenticateResponse
    {

        private IConfiguration _config;

        public AuthenticateResponse(IConfiguration config)
        {
            _config = config;
        }

        public String GenerateJwtToken(LoginRequestModel user)
        {
            string ServerAuthKey = _config["Jwt:Key"];

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ServerAuthKey));

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("user_id", user.UserId.ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(60),

                SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public String AuthenticateJwtToken(String token)
        {
            string ServerAuthKey = _config["Jwt:Key"];

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ServerAuthKey));

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                var claim_user_id = jwtToken.Claims.FirstOrDefault(x => x.Type == "user_id");

                if (claim_user_id != null)
                {
                    return claim_user_id.Value.ToString();
                }

            }
            catch
            {
                return null;
            }

            return null;

        }

    }
}