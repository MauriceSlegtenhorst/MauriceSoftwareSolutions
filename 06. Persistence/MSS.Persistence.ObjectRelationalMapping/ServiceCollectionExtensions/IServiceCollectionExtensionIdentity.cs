using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.Extensions.DependencyInjection;
using ObjectRelationalMapping.Shared.Database;
using Microsoft.AspNetCore.Identity;
using ObjectRelationalMapping.DatabaseConfigurations;

namespace MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionIdentity
    {
        public static IServiceCollection AddIdentityWithRoles(this IServiceCollection services)
        {
            services
                .AddIdentity<DomainUserAccount, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();
                

            return services;
        }
    }
}
