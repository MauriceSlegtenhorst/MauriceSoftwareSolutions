using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.Extensions.Logging;
using MSS.Application.Infrastructure.Persistence;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace MSS.Application.Logic.CommandQueries.Tests.UserAccount.Queries
{
    public class GetUserAccountDetailsQueryTests
    {
        private readonly ILogger<GetUserAccountDetailQuery> _logger;
        private readonly IUserAccountRepository _repository;
        private readonly IQueryResultFactory _resultFactory;
        private readonly IGetUserAccountDetailQuery _query;
        private readonly UserManager<DomainUserAccount> _userManager;

        public GetUserAccountDetailsQueryTests(
            ILogger<GetUserAccountDetailQuery> logger,
            IUserAccountRepository repository,
            IQueryResultFactory resultFactory,
            IGetUserAccountDetailQuery query,
            UserManager<DomainUserAccount> userManager)
        {
            _logger = logger;
            _repository = repository;
            _resultFactory = resultFactory;
            _query = query;
            _userManager = userManager;
        }

        [Fact]
        public void DpInjectionWorks()
        {
            Assert.NotNull(_logger);
            Assert.NotNull(_repository);
            Assert.NotNull(_resultFactory);
            Assert.NotNull(_query);
        }

        [Fact]
        public async void Execute_HandlesNullParameterCorrectly()
        {
            // Arrange
            var expected = new Tuple<int, QueryResult<UserAccountDetailModel>>(400, _resultFactory.Create<UserAccountDetailModel>(false, null));

            // Act
            var actual = await _query.Execute(null);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected.Item1,actual.Item1);
            Assert.False(actual.Item2.IsSucceeded);
            Assert.NotNull(actual.Item2.Messages);
        }

        [Fact]
        public async void Execute_HandlesEmptyEmailClaimCorrectly()
        {
            // Arrange
            int expected = 400;
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "username"),
                    new Claim(ClaimTypes.NameIdentifier, "userId"),
                    new Claim("name", "John Doe"),
                };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            // Act
            var actual = await _query.Execute(claimsPrincipal);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Item1);
            Assert.False(actual.Item2.IsSucceeded);
            Assert.NotNull(actual.Item2.Messages);
        }

        [Fact]
        public async void Execute_HandlesDetailAccountCreationCorrectly()
        {
            // Arrange
            var random = new Random();
            int expected = 200;
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, "maurice.slegtenhorst@outlook.com")
                };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);
         
            // Act
            var actual = await _query.Execute(claimsPrincipal);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Item1);
            Assert.True(actual.Item2.IsSucceeded);
            Assert.NotNull(actual.Item2.Result);
            Assert.NotNull(actual.Item2.Result.UserName);
        }
    }
}
