using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;
using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

using Moq;
using ObjectRelationalMapping.Shared.Database;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MSS.Domain.Common.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ObjectRelationalMapping.UserAccount;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Threading;

namespace MSS.Persistence.ObjectRelationalMapping.Tests.Shared.Database
{
    public class DatabaseContextTests
    {
        // #region Old test
        //private readonly DatabaseContext _dbContext;

        //public DatabaseContextTests()
        //{
        //    _dbContext = MockDbSetup.MockDatabaseContext().Object;
        //}


        //[Theory]
        //[InlineData(1)]
        //[InlineData(0)]
        ////[InlineData(long.MaxValue)]
        //public void Set_ShouldAddAccounts(long toBeAddedAccounts)
        //{
        //    // Arange
        //    long expectedEntityCount = _dbContext.UserAccounts.LongCount() + toBeAddedAccounts;
        //    var random = new Random();

        //    var entitiesToBeAdded = new List<DomainUserAccount>();

        //    for (long i = 0; i < toBeAddedAccounts; i++)
        //    {
        //        entitiesToBeAdded.Add(new DomainUserAccount
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Email = $"Bertus{i}@outlook.com",
        //            FirstName = $"FirstName{i}",
        //            Affix = $"Affix{i}",
        //            LastName = $"LastName{i}",
        //            CreationDateUTC = DateTime.UtcNow,
        //            UserName = $"UserName{i}",
        //            PasswordHash = $"PasswordHash{i}",
        //            EmailConfirmed = ((random.Next(0, 1) == 0) ? true : false),
        //            IsAdmitted = ((random.Next(0, 1) == 0) ? true : false),
        //            TwoFactorEnabled = ((random.Next(0, 1) == 0) ? true : false)
        //        });
        //    }

        //    // Act
        //    if (toBeAddedAccounts == 1)
        //        _dbContext.Set<DomainUserAccount>().Add(entitiesToBeAdded[0]);
        //    else
        //        _dbContext.Set<DomainUserAccount>().AddRange(entitiesToBeAdded);

        //    long actualEntityCount = _dbContext.UserAccounts.Count();

        //    // Assert
        //    Assert.Equal(expectedEntityCount, actualEntityCount);
        //}
        // #endregion

        private readonly DbContextOptions<DatabaseContext> _options;
        private readonly Random _random;

        public DatabaseContextTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "master")
            .Options;

            _random = new Random();
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(1f)]
        [InlineData(100000f)]
        public async Task SaveAsync_ShouldSaveAsync(long amountOfEntriesToBeAdded)
        {
            // Arrange
            using (var _dbContext = new DatabaseContext(_options))
            {
                var accountData = new List<DomainUserAccount>();
                for (long i = 0; i < amountOfEntriesToBeAdded; i++)
                {
                    accountData.Add(new DomainUserAccount
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = $"Bertus{i}@outlook.com",
                        FirstName = $"FirstName{i}",
                        Affix = $"Affix{i}",
                        LastName = $"LastName{i}",
                        CreationDateUTC = DateTime.UtcNow,
                        UserName = $"UserName{i}",
                        PasswordHash = $"PasswordHash{i}",
                        EmailConfirmed = ((_random.Next(0, 1) == 0) ? true : false),
                        IsAdmitted = ((_random.Next(0, 1) == 0) ? true : false),
                        TwoFactorEnabled = ((_random.Next(0, 1) == 0) ? true : false)
                    });
                }

                long expectedAffectedEntries = accountData.LongCount();

                _dbContext.Set<DomainUserAccount>().AddRange(accountData);

                // Act
                long actualAffectedEntries = await _dbContext.SaveAsync(CancellationToken.None);

                // Assert
                Assert.Equal(expectedAffectedEntries, actualAffectedEntries);
            }
        }

        [Fact]
        public async Task SaveAsync_ShouldBeCancellable()
        {

        }

        public async Task SaveAsync_ShouldLogAndRethrowExceptions()
        {

        }
    }
}
