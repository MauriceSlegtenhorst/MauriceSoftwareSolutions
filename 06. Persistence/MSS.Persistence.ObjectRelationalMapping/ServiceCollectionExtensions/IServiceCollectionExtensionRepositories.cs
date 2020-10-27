using Microsoft.Extensions.DependencyInjection;
using MSS.Application.Infrastructure.Persistence;
using MSS.Persistence.ObjectRelationalMapping.Shared;
using ObjectRelationalMapping.Credit;
using ObjectRelationalMapping.UserAccount;

namespace MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<ICreditCategoryRepository, CreditCategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
