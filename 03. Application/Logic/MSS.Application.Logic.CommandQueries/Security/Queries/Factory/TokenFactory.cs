using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using MSS.Domain.Concrete.DatabaseEntities.Identity;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.Factory
{
    public sealed class TokenFactory : ITokenFactory
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly UserManager<DomainUserAccount> _userManager;
        private readonly SigningCredentials _signingCredentials;
        private readonly string _issuer;
        private readonly string _audience;

        /// <exception cref="NullReferenceException">Thrown when a variable could not be retreived from the environment variables.</exception>
        public TokenFactory(UserManager<DomainUserAccount> userManager)
        {
            _issuer = Environment.GetEnvironmentVariable("MSSValidIssuer") ?? throw new NullReferenceException("ValidIssuer evironment variable not found.");
            _audience = Environment.GetEnvironmentVariable("MSSValidAudience") ?? throw new NullReferenceException("ValidAudience evironment variable not found.");
            var issuerKey = Environment.GetEnvironmentVariable("MSSValidateIssuerSigningKey") ?? throw new NullReferenceException("Issuer key was null or empty. Could not retreive data from enviroment variables.");
            
            _tokenHandler = new JwtSecurityTokenHandler();
            _userManager = userManager;

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerKey));
            _signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        }



        /// <exception cref="ArgumentException">Thrown when the string parameter userName is invalid</exception>
        /// <exception cref="NullReferenceException">Thrown when the no user was found with the provided username string</exception>
        public async Task<SessionAuthenticationToken> Create(string userName, bool isPersistent)
        {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException($"Parameter {nameof(userName)} cannot be null or empty.");

            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
                throw new NullReferenceException("No user was found with this username");

            string javascriptUTCIssuedAt = new TimeSpan(DateTime.UtcNow.Ticks).TotalMilliseconds.ToString();
            string javascriptUTCExpirationTime = new TimeSpan(DateTime.UtcNow.AddMinutes(user.SessionTimeMinutes).Ticks).TotalMilliseconds.ToString();

            var claims = new Collection<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _audience),
                new Claim(JwtRegisteredClaimNames.Iat, javascriptUTCIssuedAt),
                new Claim(JwtRegisteredClaimNames.Exp, javascriptUTCExpirationTime),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.Affix?.ToString().Append(' ')}{user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.IsPersistent, isPersistent.ToString())
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                signingCredentials: _signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(user.SessionTimeMinutes));

            return new SessionAuthenticationToken(
                userId: user.Id,
                loginProvider: _issuer,
                userName: user.UserName,
                jwtSecurityToken: _tokenHandler.WriteToken(token));
        }
    }
}
