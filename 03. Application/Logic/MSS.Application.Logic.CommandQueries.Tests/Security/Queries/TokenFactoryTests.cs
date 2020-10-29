using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Xunit;
using MSS.Application.Logic.CommandQueries.Security.Queries.Factory;
using System.Linq;
using System.Security.Claims;
using System.Globalization;
using System.Diagnostics;

namespace MSS.Application.Logic.CommandQueries.Tests.Security.Queries
{
    public class TokenFactoryTests
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly UserManager<DomainUserAccount> _userManager;
        private readonly SigningCredentials _signingCredentials;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly ITokenFactory _tokenFactory;

        public TokenFactoryTests(
            UserManager<DomainUserAccount> userManager,
            ITokenFactory tokenFactory)
        {
            _issuer = Environment.GetEnvironmentVariable("MSSValidIssuer") ?? throw new NullReferenceException("ValidIssuer evironment variable not found.");
            _audience = Environment.GetEnvironmentVariable("MSSValidAudience") ?? throw new NullReferenceException("ValidAudience evironment variable not found.");
            var issuerKey = Environment.GetEnvironmentVariable("MSSValidateIssuerSigningKey") ?? throw new NullReferenceException("Issuer key was null or empty. Could not retreive data from enviroment variables.");

            _tokenHandler = new JwtSecurityTokenHandler();
            _userManager = userManager;

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerKey));
            _signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            _tokenFactory = tokenFactory;
        }

        [Fact]
        public void DpInjectionWorks()
        {
            Assert.NotNull(_tokenHandler);
            Assert.NotNull(_userManager);
            Assert.NotNull(_signingCredentials);
            Assert.NotNull(_issuer);
            Assert.NotNull(_audience);
            Assert.NotNull(_tokenFactory);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        public async void Create_ThrowsWhenParametersAreInvalid(string userName, bool isPersistent)
        {
            // Assert
            await Assert.ThrowsAsync<ArgumentException>(() =>
            {
                // Act
                return _tokenFactory.Create(userName, isPersistent);
            });
        }

        [Fact]
        public async void Create_ThrowsIfUserNotFound()
        {
            // Assert
            await Assert.ThrowsAsync<NullReferenceException>(() =>
            {
                // Act
                return _tokenFactory.Create("invaliduser", false);
            });
        }

        [Fact]
        public async void Create_ReturnsAValidSessionAuthenticationToken()
        {
            // Arrange
            var handler = new JwtSecurityTokenHandler();
            var expectedEmail = "maurice.slegtenhorst@outlook.com";
            var expectedName = "Maurice Slegtenhorst";
            var expectedNameIdentifier = "maurice.slegtenhorst@outlook.com";

            // Act
            var sessionAuthenticationToken = await _tokenFactory.Create("maurice.slegtenhorst@outlook.com", false);
            var jwtSecurityToken = handler.ReadJwtToken(sessionAuthenticationToken.Value);
            
            var actualEmail = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
            var actualName = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
            var actualNameIdentifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            var actualIssuedAtDateTime = DateTime.UnixEpoch.AddSeconds(Convert.ToDouble(
                jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Iat).Value));
            var actualExpireDateTime = DateTime.UnixEpoch.AddSeconds(Convert.ToDouble(
                jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Exp).Value));

            // Assert
            Assert.NotNull(sessionAuthenticationToken);
            Assert.NotNull(jwtSecurityToken);

            Assert.Equal(expectedEmail, actualEmail);
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedNameIdentifier, actualNameIdentifier);

            // Failing not understanding how to fix factory
            Debug.WriteLine(actualIssuedAtDateTime + " <= " + DateTime.UtcNow);
            Assert.True(actualIssuedAtDateTime <= DateTime.UtcNow);

            // 29/10/2020 20:47:58 > 29/10/2020 20:37:58 = true => last debugged test result
            Assert.True(actualExpireDateTime > DateTime.UtcNow);
        }
    }
}
