using Microsoft.Extensions.DependencyInjection;
using Weelo.Core.Identity;
using Weelo.Core.Interfaces;
using Weelo.Core.Mappers;
using Weelo.Core.Services;
using Weelo.Infraestructure.Data;

namespace Weelo.Api.Extension
{
    public static class DIExtensions
    {
        internal static IServiceCollection AddDIExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));


            services.AddScoped(typeof(IAsyncRepository<>), typeof(GenericEfRepository<>));

            services.AddScoped<ITokenClaims, TokenClaims>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPropertyImageService, PropertyImageService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IImagesService, ImagesService>();

            return services;
        }

    }
}
