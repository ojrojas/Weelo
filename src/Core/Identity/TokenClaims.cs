using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Weelo.Core.Entities;
using Weelo.Core.Interfaces;

namespace Weelo.Core.Identity
{
    /// <summary>
    /// Token claim Services
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class TokenClaims : ITokenClaims
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="configuration">Configuration application</param>
        public TokenClaims(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
        /// <summary>
        /// Get Token jwt
        /// </summary>
        /// <param name="user">User login application</param>
        /// <returns>jwt string token</returns>
        public async Task<string> GetTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtOptions:JwtSecret"]);
            var claims = new List<Claim>();

            foreach (PropertyInfo prop in user.GetType().GetProperties())
            {
                _ = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                if (prop.Name != "Password")
                    if (prop.GetValue(user, null) != null)
                        claims.Add(new Claim(prop.Name, prop.GetValue(user, null).ToString()));
            }

            await Task.CompletedTask;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
