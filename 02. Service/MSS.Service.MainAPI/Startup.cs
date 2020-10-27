using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSS.Application.Logic.CommandQueries.ServiceCollectionExtensions;
using MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions;

namespace MSS.Service.MainAPI
{
    public class Startup
    {
        /// Transient objects are always different; a new instance is provided to every controller and every service.
        /// Scoped objects are the same within a request, but different across different requests.
        /// Singleton objects are the same for every object and every request.

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase();
            services.AddIdentityWithRoles();
            services.AddJWTAuthentication();
            services.AddRepositories();
            services.AddCommandQueries();
            services.AddFactories();

            services.AddControllers();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
