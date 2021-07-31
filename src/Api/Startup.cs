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
    public class Startup
    {
        private const string CORS_POLICY = "WeeloCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<WeeloDbContext>(c =>
            //c.UseSqlServer(Configuration.GetConnectionString("Connection")));

            services.AddDbContext<WeeloDbContext>(c =>
           c.UseSqlite(Configuration.GetConnectionString("ConnectionSqlite")));

            services.AddControllers();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            services.AddDIExtensions();

            services.AddJwtAuthentication(Configuration);
            services.AddCorsExtension(CORS_POLICY);
            services.AddSwaggerExtension();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorMiddleware>();

            app.UseHttpsRedirection();

            app.UseSwaggerExtensions();

            app.UseRouting();

            app.UseCors(CORS_POLICY);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
