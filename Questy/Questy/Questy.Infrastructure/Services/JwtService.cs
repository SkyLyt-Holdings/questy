using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.Services
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ExpirationTime { get; set; }
    }

    public interface IJwtManagement
    {
        JwtSecurityToken GenerateJwtToken(User user, bool isAdmin);
    }

    public class JwtService: IJwtManagement
    {
        private readonly JwtSettings jwtSettings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings.Value;
        }

        public JwtSecurityToken GenerateJwtToken(User user, bool isAdmin)
        {

            // list of claims we want to use
            var registeredClaims = new[]
            {
                new Claim("Username", user.Username),
                new Claim("Email", user.Email),
                new Claim("IsAdmin", isAdmin.ToString())
            };

            // security key generated based on the secret key stored in appsettings.json
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

            // generate signing credentials to verify the JWT sign
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // build token
            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Issuer,
                registeredClaims,
                expires: DateTime.Now.AddHours(int.Parse(jwtSettings.ExpirationTime)),
                signingCredentials: signingCredentials
            );

            // additional data in payload
            //token.Payload["variablehere"] = "test";

            // return token
            return token;
                
        }
    }
}
