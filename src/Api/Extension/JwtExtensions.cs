using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Weelo.Api.Extension
{
    /// <summary>
    /// Extension Jwt
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public static class JwtExtensions
    {
        /// <summary>
        /// AddJwtAuthentication from application
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">Configuration app</param>
        /// <returns>Services jwt</returns>
        internal static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration["JwtOptions:JwtSecret"]);
            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
