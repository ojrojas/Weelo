using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Weelo.Api.Extension
{
    /// <summary>
    /// Extension Cors
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    internal static class CorsExtensions
    {
        /// <summary>
        /// Cors Extensions
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="corsName">Name cors for application</param>
        /// <param name="configuration">Configuration url cors</param>
        /// <returns>Services</returns>
        public static IServiceCollection AddCorsExtension(this IServiceCollection services, string corsName, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsName,
                                  builder =>
                                  {
                                      builder.WithOrigins(/* Policy Url */  configuration["Cors:UrlCors"]);
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });


            return services;
        }
    }
}
