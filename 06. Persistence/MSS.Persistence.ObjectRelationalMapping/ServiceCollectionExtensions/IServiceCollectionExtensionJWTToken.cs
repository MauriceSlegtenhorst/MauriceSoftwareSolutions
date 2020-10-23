using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ObjectRelationalMapping.DatabaseConfigurations;

namespace MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionJWTToken
    {
        private static readonly DbConfigurations dbConfigurations = DbConfigurations.Build();

        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Audience = ORMConstants.OPEN_ID_CONNECT_AUDIENCE;
                    options.TokenValidationParameters = dbConfigurations._tokenValidationParameters;
                });

            return services;
        }
    }
}
