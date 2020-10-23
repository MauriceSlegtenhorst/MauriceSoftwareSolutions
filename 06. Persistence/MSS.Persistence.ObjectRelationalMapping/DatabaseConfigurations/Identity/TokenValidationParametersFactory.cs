using Microsoft.IdentityModel.Tokens;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using System;
using System.Text;

namespace MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations.Identity
{
    internal sealed class TokenValidationParametersFactory
    {
        private TokenValidationParametersFactory() { }

        internal static TokenValidationParameters Build(string issuerSigningKey)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey)),
                ClockSkew = TimeSpan.Zero,
                ValidAudience = Endpoints.API_BASE_ADDRESS,
                ValidIssuer = Endpoints.API_BASE_ADDRESS
            };
        }
    }
}
