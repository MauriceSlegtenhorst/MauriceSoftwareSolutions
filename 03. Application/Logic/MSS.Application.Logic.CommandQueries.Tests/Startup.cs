using Microsoft.Extensions.DependencyInjection;
using MSS.Application.Logic.CommandQueries.ServiceCollectionExtensions;
using MSS.Persistence.ObjectRelationalMapping.ServiceCollectionExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace MSS.Application.Logic.CommandQueries.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase();
            services.AddIdentityWithRoles();
            services.AddJWTAuthentication();
            services.AddRepositories();
            services.AddCommandQueries();
            services.AddFactories();
        }
    }
}
