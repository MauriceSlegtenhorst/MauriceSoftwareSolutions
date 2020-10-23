using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations.Identity;
using System;
using System.Diagnostics;

namespace ObjectRelationalMapping.DatabaseConfigurations
{
    internal sealed class DbConfigurations
    {
        internal readonly string _sqlConnectionString;
        internal readonly string _issuerSigningKey;
        internal readonly TokenValidationParameters _tokenValidationParameters;
        internal readonly IdentityOptions _identityOptions;

        /// <exception cref="NullReferenceException">Thrown when one of the enviroment variables was not found. This results in an empty or null string variable which is not allowed.</exception>
        private DbConfigurations()
        {
            string connectionString = Environment.GetEnvironmentVariable("MSSConnectionString");
            _sqlConnectionString = connectionString;

            if (String.IsNullOrEmpty(connectionString))
                throw new NullReferenceException("connstring = null or empty");

            string issuerSigningKey = Environment.GetEnvironmentVariable("MSSValidateIssuerSigningKey");
            
            if (String.IsNullOrEmpty(connectionString))
                throw new NullReferenceException("key = null or empty");

            _issuerSigningKey = issuerSigningKey;

            _tokenValidationParameters = TokenValidationParametersFactory.Build(_issuerSigningKey);

            _identityOptions = IdentityOptionsFactory.Build();
        }

        /// <exception cref="NullReferenceException">Thrown when one of the enviroment variables was not found. This results in an empty or null string variable which is not allowed.</exception>
        internal static DbConfigurations Build()
        {
            return new DbConfigurations();
        }
    }
}
