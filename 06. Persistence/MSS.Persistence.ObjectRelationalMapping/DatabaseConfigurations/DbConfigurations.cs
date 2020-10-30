using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations.Identity;
using System;
using System.Diagnostics;

namespace ObjectRelationalMapping.DatabaseConfigurations
{
    public sealed class DbConfigurations
    {
        internal readonly string _sqlConnectionString;
        internal readonly string _issuerSigningKey;
        internal readonly TokenValidationParameters _tokenValidationParameters;
        public readonly IdentityOptions _identityOptions;

        /// <exception cref="NullReferenceException">Thrown when one of the enviroment variables was not found. This results in an empty or null string variable which is not allowed.</exception>
        private DbConfigurations()
        {
            string connectionString = Environment.GetEnvironmentVariable("MSSConnectionString");

            if (String.IsNullOrEmpty(connectionString))
                throw new NullReferenceException("connstring = null or empty");

            _sqlConnectionString = connectionString;

            _issuerSigningKey = Environment.GetEnvironmentVariable("MSSValidateIssuerSigningKey");
            
            if (String.IsNullOrEmpty(_issuerSigningKey))
                throw new NullReferenceException("key = null or empty");

            _tokenValidationParameters = TokenValidationParametersFactory.Build(_issuerSigningKey);

            _identityOptions = IdentityOptionsFactory.Build();
        }

        /// <exception cref="NullReferenceException">Thrown when one of the enviroment variables was not found. This results in an empty or null string variable which is not allowed.</exception>
        public static DbConfigurations Build()
        {
            return new DbConfigurations();
        }
    }
}
