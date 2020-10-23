using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using MSS.Domain.Concrete.DatabaseEntities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;

namespace MSS.Persistence.ObjectRelationalMapping.DatabaseConfigurations.Identity
{
    internal sealed class TokenFactory
    {
        private TokenFactory() { }

        internal static async Task<SessionAuthenticationToken> BuildToken(DomainUserAccount userAccount, UserManager<DomainUserAccount> userManager, string issuerSigningKey, double sessionTime = 10)
        {
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, $"{userAccount.Email.GetHashCode()}{DateTime.UtcNow}{userAccount.PasswordHash.GetHashCode()}"),
                new Claim(ClaimTypes.Name, userAccount.ToString()),
                new Claim(ClaimTypes.Email, userAccount.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in await userManager.GetRolesAsync(userAccount))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationDate = DateTime.UtcNow.AddMinutes(sessionTime);

            var token = new JwtSecurityToken(
               issuer: Endpoints.API_BASE_ADDRESS,
               audience: Endpoints.API_BASE_ADDRESS,
               claims: claims,
               expires: expirationDate,
               signingCredentials: creds);

            return new SessionAuthenticationToken(
                userId: userAccount.Id,
                loginProvider: ORMConstants.LOGIN_PROVIDER,
                userName: userAccount.FirstName ?? userAccount.Email,
                expirationDate: expirationDate,
                jwtSecurityToken: new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
