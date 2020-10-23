using Microsoft.Extensions.DependencyInjection;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;

namespace MSS.Application.Logic.CommandQueries.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionFactories
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountFactory, UserAccountFactory>();

            return services;
        }
    }
}
