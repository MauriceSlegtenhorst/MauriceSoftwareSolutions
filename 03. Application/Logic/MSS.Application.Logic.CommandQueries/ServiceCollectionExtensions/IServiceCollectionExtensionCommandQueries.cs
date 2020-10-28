using Microsoft.Extensions.DependencyInjection;
using MSS.Application.Logic.CommandQueries.Security.Queries.LogIn;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;

namespace MSS.Application.Logic.CommandQueries.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionCommandQueries
    {
        public static IServiceCollection AddCommandQueries(this IServiceCollection services)
        {
            // User account
            services.AddScoped<IGetUserAccountsListQuery, GetUserAccountsListQuery>();
            services.AddScoped<IGetUserAccountDetailQuery, GetUserAccountDetailQuery>();
            services.AddScoped<ICreateUserAccountCommand, CreateUserAccountCommand>();

            // Security
            services.AddScoped<ILogInQuery, LogInQuery>();

            return services;
        }
    }
}
