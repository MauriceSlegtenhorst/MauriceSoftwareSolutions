using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MSS.Application.Logic.CommandQueries.Tests.UserAccount.Commands.CreateUserAccount.Factory
{
    public class UserAccountFactoryTests
    {
        // Arrange
        private readonly UserAccountFactory _accountFactory;

        public UserAccountFactoryTests()
        {
            _accountFactory = new UserAccountFactory();
        }

        [Theory]
        [InlineData(null, 10, null,null,null,null)]
        [InlineData("", 10, null, null, null, null)]
        [InlineData(null, 10, "", null, null, null)]
        [InlineData(null, 10, null, "", null, null)]
        [InlineData(null,10, null, null, "", null)]
        [InlineData(null, 10, null, null, null, "")]
        public void Create_ShouldNotReturnNull(
            string email,
            int sessionTimeMinutes,
            string firstName = null,
            string lastName = null,
            string affix = null,
            string userName = null)
        {
            var account = _accountFactory.Create(email, sessionTimeMinutes, firstName, lastName, affix, userName);

            Assert.NotNull(account);
        }
    }
}
