using Microsoft.Extensions.DependencyInjection;

namespace Weelo.Api.Extension
{
    internal static class CorsExtensions
    {
        public static IServiceCollection AddCorsExtension(this IServiceCollection services, string corsName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: corsName,
                                  builder =>
                                  {
                                      builder.WithOrigins(/* Policy */);
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });


            return services;
        }
    }
}
