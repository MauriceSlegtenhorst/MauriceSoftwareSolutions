using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ObjectRelationalMapping.DatabaseConfigurations;
using System;

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
#if DEBUG
                    options.RequireHttpsMetadata = false;
#endif
                    options.SaveToken = true;
                    options.Audience = Environment.GetEnvironmentVariable("MSSValidAudience") ?? throw new NullReferenceException("ValidAudience evironment variable not found.");
                    options.TokenValidationParameters = dbConfigurations._tokenValidationParameters;
                });

            return services;
        }
    }
}
