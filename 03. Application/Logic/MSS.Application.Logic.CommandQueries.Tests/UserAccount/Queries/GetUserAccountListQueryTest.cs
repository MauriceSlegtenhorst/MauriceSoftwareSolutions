using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MSS.Application.Logic.CommandQueries.Tests.UserAccount.Queries
{
    public class GetUserAccountListQueryTest
    {
        private readonly IGetUserAccountsListQuery _query;
        private readonly IQueryResultFactory _resultFactory;
        public GetUserAccountListQueryTest(IGetUserAccountsListQuery query, IQueryResultFactory resultFactory)
        {
            _query = query;
            _resultFactory = resultFactory;
        }

        [Fact]
        public async void Execute_ReturnsListOfUsers()
        {
            // Arrange
            var expectedCode = 200;

            // Act
            var actualResultTuple = await _query.Execute();

            // Assert
            Assert.NotNull(actualResultTuple);
            Assert.Equal(expectedCode, actualResultTuple.Item1);
            Assert.True(actualResultTuple.Item2.IsSucceeded);
            Assert.Null(actualResultTuple.Item2.Messages);
            Assert.IsType<List<UserAccountsListItemModel>>(actualResultTuple.Item2.Result);
        }
    }
}
