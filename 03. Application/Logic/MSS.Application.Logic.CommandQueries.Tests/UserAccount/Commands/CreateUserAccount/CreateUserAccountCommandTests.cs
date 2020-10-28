using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using Microsoft.EntityFrameworkCore;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using System;
using ObjectRelationalMapping.Shared;
using Moq;
using System.Threading;
using MSS.Persistence.ObjectRelationalMapping.Shared;

namespace MSS.Application.Logic.CommandQueries.Tests.UserAccount.Commands.CreateUserAccount
{
    public class CreateUserAccountCommandTests
    {
        //private const string ErrorsKeepComingMessage = "If you keep receiving error please fill in our customer support form. Thank you in advance!";
        //private const string ErrorTryAgainMessage = "Please check if you got any mail from us. If you did not receive mail from us, please try and fill in the form again.";

        private readonly UserAccountFactory _accountFactory;
        //private readonly CommandResultFactory _resultFactory;

        public CreateUserAccountCommandTests()
        {
            _accountFactory = new UserAccountFactory();
            //_resultFactory = new CommandResultFactory();
        }

        [Fact]
        public async Task Execute_SouldAddAccountToStore()
        {
            // Arrange -------------------------------------------------
            var model = new CreateUserAccountModel
            {
                FirstName = "Bertus",
                Affix = "de",
                LastName = "Vreedzame",
                Email = "bertusdevreedzame@outlook.com",
                UserName = "Bertus",
                Password = "bertusdevreedzamepassword"

            };

            var _users = new List<DomainUserAccount>
            {
                _accountFactory.Create("berta001@outlook.com"),
                _accountFactory.Create("berta002@outlook.com"),
                _accountFactory.Create("berta003@outlook.com")
            };

            var _userManager = MockUserManagerHolder.MockUserManager<DomainUserAccount>(_users).Object;

            var userAccount = _accountFactory.Create(
               model.Email,
               model.SessionTimeMinutes,
               model.FirstName,
               model.LastName,
               model.Affix,
               model.UserName);

            int expectedUserStoreCount = _users.Count + 1;

            // Act -------------------------------------------------
            await _userManager.CreateAsync(userAccount, model.Password);

            // Assert -------------------------------------------------
            Assert.Equal(expectedUserStoreCount, _users.Count);
        }

        //[Fact]
        //public async Task Execute_ShouldSaveChangesToDatabase()
        //{
        //    // Arrange
        //    int affectedEntriesCount = 0;
        //    var randomNumberGenerator = new Random();
        //    var _usersStore = new List<DomainUserAccount>();
        //    for (int i = 0; i < randomNumberGenerator.Next(1 ,99); i++)
        //    {
        //        _usersStore.Add(new DomainUserAccount
        //        {
        //            FirstName = "Bertus",
        //            Affix = "de",
        //            LastName = "Vreedzame",
        //            Email = $"bertusdevreedzame{i}@outlook.com",
        //            UserName = "Bertus",
        //            PasswordHash = $"bertusdevreedzamepassword{i}"

        //        });
        //    }
        //    var expectedEntriesCount = _usersStore.Count;
        //    var token = new CancellationToken();
        //    var dbContext = new Mock<IDatabaseContext>(_usersStore);
        //    dbContext.Setup(c => c.SaveAsync(token)).Verifiable();
        //    var _unitOfWork = new UnitOfWork(dbContext.Object);

        //    // Act
        //    affectedEntriesCount = await _unitOfWork.SaveAsync(token);


        //    // Assert
        //    Assert.Equal(expectedEntriesCount, affectedEntriesCount);
        //}
    }
}
