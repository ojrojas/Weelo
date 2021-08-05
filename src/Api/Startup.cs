using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weelo.Api.Extension;
using Weelo.Infraestructure.Data;

namespace Weelo.Api
{
    /// <summary>
    /// Startup application 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/08/2021</date>
    public class Startup
    {
        /// <summary>
        /// Cors configuration
        /// </summary>
        private const string CORS_POLICY = "WeeloCors";

        /// <summary>
        /// Startup application 
        /// </summary>
        /// <param name="configuration">Configuration application</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configuration srevices application
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<WeeloDbContext>(c =>
            //c.UseSqlServer(Configuration.GetConnectionString("Connection")));

            /// db configuration
            services.AddDbContext<WeeloDbContext>(c =>
           c.UseSqlite(Configuration.GetConnectionString("ConnectionSqlite")));

            // configuration DI
            services.AddDIExtensions();
            // Configuration Jwt
            services.AddJwtAuthentication(Configuration);
            // Configuration cors
            services.AddCorsExtension(CORS_POLICY, Configuration);
            // configuration memory
            services.AddDistributedMemoryCache();

            services.AddControllers();

            // Configuration swagger extension
            services.AddSwaggerExtension();

            services.AddMemoryCache();
        }

        /// <summary>
        /// Builder application 
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="env">Environment configuration</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //configuration Errormiddleware
            app.UseMiddleware<ErrorMiddleware>();

            app.UseHttpsRedirection();

            app.UseSwaggerExtensions();

            app.UseRouting();

            app.UseAuthentication();

            /// configuration cors policity
            app.UseCors(CORS_POLICY);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
