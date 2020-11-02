using Microsoft.Extensions.DependencyInjection;
using MSS.CrossCuttingConcerns.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.CrossCuttingConcerns.Concrete.Validation.IServiceCollectionExtensions
{
    public static class IServiceCollectionExtensionValidation
    {
        public static IServiceCollection AddEmailVerificationService(this IServiceCollection services)
        {
            services.AddScoped<IEmailVerificationService, EmailVerificationService>();
            return services;
        }
    }
}
