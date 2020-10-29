using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using Xunit;

namespace MSS.Application.Logic.CommandQueries.Tests.QueryCommandResult.Factory
{
    public class CommandResultFactoryTests
    {
        [Theory]
        [InlineData(true, null)]
        [InlineData(true, new string[] { "test", null, null })]
        [InlineData(true, new string[] { null , null, null })]
        public void Create_CommandResultShouldNotBeNull(bool isSucceded, string[] messages = null)
        {
            // Arrange
            var commandResultFactory = new CommandResultFactory();

            // Act
            var actualCommandResult = commandResultFactory.Create(isSucceded, messages);

            // Assert
            Assert.NotNull(actualCommandResult);
        }
    }
}
