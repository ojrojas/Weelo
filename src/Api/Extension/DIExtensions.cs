using Microsoft.Extensions.DependencyInjection;
using Weelo.Core.Identity;
using Weelo.Core.Interfaces;
using Weelo.Core.Mappers;
using Weelo.Core.Services;
using Weelo.Infraestructure.Data;

namespace Weelo.Api.Extension
{
    /// <summary>
    /// Extension DI Manager
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>02/08/2021</date>
    public static class DIExtensions
    {
        /// <summary>
        /// AddDIExtension from servicecollection
        /// </summary>
        /// <param name="services">IServiceCollection </param>
        /// <returns>Services</returns>
        internal static IServiceCollection AddDIExtensions(this IServiceCollection services)
        {
            ///Mappers
            services.AddAutoMapper(typeof(MapperProfile));
            
            /// Services EF Repository Generic IOC
            services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericEfRepository<>));

            /// Scopes Services
            services.AddScoped<ITokenClaims, TokenClaims>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPropertyImageService, PropertyImageService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyTraceService, PropertyTraceService>();
            services.AddScoped<IImagesService, ImagesService>();

            return services;
        }

    }
}
