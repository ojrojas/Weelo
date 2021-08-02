using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Weelo.Api.Extension
{
    internal static class CorsExtensions
    {
        public static IServiceCollection AddCorsExtension(this IServiceCollection services, string corsName, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsName,
                                  builder =>
                                  {
                                      builder.WithOrigins(/* Policy */  configuration["Cors:UrlCors"]);
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });


            return services;
        }
    }
}
