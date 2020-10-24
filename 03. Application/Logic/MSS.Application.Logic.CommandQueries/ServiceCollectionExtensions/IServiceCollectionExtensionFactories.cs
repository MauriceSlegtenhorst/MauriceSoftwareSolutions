using Microsoft.Extensions.DependencyInjection;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory;

namespace MSS.Application.Logic.CommandQueries.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionFactories
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountFactory, UserAccountFactory>();
            services.AddScoped<ICommandResultFactory, CommandResultFactory>();
            services.AddScoped<IQueryResultFactory, QueryResultFactory>();

            return services;
        }
    }
}
