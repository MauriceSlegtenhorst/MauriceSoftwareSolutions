
using Microsoft.Extensions.DependencyInjection;
using ObjectRelationalMapping.Shared.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ObjectRelationalMapping.DatabaseConfigurations;
using ObjectRelationalMapping.Shared;

namespace MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionSqlDatabase
    {
        private static readonly DbConfigurations dbConfigurations = DbConfigurations.Build();

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(dbConfigurations._sqlConnectionString, optionsBuilder =>
                    optionsBuilder.MigrationsAssembly(typeof(DatabaseContext).Assembly.GetName().Name)));

            services.AddScoped<IDatabaseContext, DatabaseContext>();

            services.Configure<IdentityOptions>(options => options = dbConfigurations._identityOptions);

            return services;
        }
    }
}
