using Microsoft.Extensions.DependencyInjection;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;

namespace MSS.Application.Logic.CommandQueries.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionCommandQueries
    {
        public static IServiceCollection AddCommandQueries(this IServiceCollection services)
        {
            services.AddScoped<IGetUserAccountsListQuery, GetUserAccountsListQuery>();
            services.AddScoped<IGetUserAccountDetailQuery, GetUserAccountDetailQuery>();
            services.AddScoped<ICreateUserAccountCommand, CreateUserAccountCommand>();

            return services;
        }
    }
}
