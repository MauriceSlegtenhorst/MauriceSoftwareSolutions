using Microsoft.Extensions.DependencyInjection;
using MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions;

namespace MSS.Persistence.ObjectRelationalMapping.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase();

            services.AddIdentityWithRoles();
            services.AddJWTAuthentication();
            services.AddRepositories();
        }
    }
}
