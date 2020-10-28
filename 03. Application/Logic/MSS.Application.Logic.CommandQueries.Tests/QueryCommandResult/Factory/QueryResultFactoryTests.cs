using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using System;
using Xunit;

namespace MSS.Application.Logic.CommandQueries.Tests.QueryCommandResult.Factory
{
    public class QueryResultFactoryTests
    {
        [Theory]
        [InlineData(true, "blablabla", new string[] { "jajaja", "jajajaja" })]
        [InlineData(false, null, null)]
        public void Create_QueryResultShouldNotBeNull(bool isSucceded, string resultItem, string[] messages = null)
        {
            // Arrange
            var queryResultFactory = new QueryResultFactory();

            // Act
            var actualQueryResult = queryResultFactory.Create<String>(isSucceded, resultItem, messages);

            // Assert
            Assert.NotNull(actualQueryResult);

        }
    }
}
