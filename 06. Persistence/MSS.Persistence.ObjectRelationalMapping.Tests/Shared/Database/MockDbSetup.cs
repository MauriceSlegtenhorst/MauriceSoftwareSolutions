using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;
using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

using Moq;
using ObjectRelationalMapping.Shared.Database;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ObjectRelationalMapping.DatabaseConfigurations;
using Microsoft.Extensions.Logging;

namespace MSS.Persistence.ObjectRelationalMapping.Tests.Shared.Database
{
    public class MockDbSetup
    {
        public static Mock<DatabaseContext> MockDatabaseContext()
        {
            var mockDatabaseContext = new Mock<DatabaseContext>(new DbContextOptions<DatabaseContext>()) { CallBase = true };
            var random = new Random();

            #region Mock users accounts
            var accountData = new List<DomainUserAccount>();
            for (int i = 0; i < 50; i++)
            {
                accountData.Add(new DomainUserAccount { Id = Guid.NewGuid().ToString(), Email = $"Bertus{i}@outlook.com", FirstName = $"FirstName{i}", Affix = $"Affix{i}", LastName=$"LastName{i}", 
                    CreationDateUTC=DateTime.UtcNow, UserName = $"UserName{i}", PasswordHash = $"PasswordHash{i}", EmailConfirmed = ((random.Next(0,1) == 0) ? true : false), IsAdmitted = ((random.Next(0,1) == 0) ? true : false), 
                    TwoFactorEnabled = ((random.Next(0,1) == 0) ? true : false)});
            }

            var qAccountData = accountData.AsQueryable();

            var mockAccountsSet = new Mock<DbSet<DomainUserAccount>>();
            mockAccountsSet.As<IQueryable<DomainUserAccount>>().Setup(m => m.Provider).Returns(qAccountData.Provider);
            mockAccountsSet.As<IQueryable<DomainUserAccount>>().Setup(m => m.Expression).Returns(qAccountData.Expression);
            mockAccountsSet.As<IQueryable<DomainUserAccount>>().Setup(m => m.ElementType).Returns(qAccountData.ElementType);
            mockAccountsSet.As<IQueryable<DomainUserAccount>>().Setup(m => m.GetEnumerator()).Returns(qAccountData.GetEnumerator());

            mockDatabaseContext.Setup(c => c.UserAccounts).Returns(mockAccountsSet.Object);
            #endregion

            #region Mock CreditCategories
            var creditCategoryData = new List<DomainCreditCategory>();
            for (int i = 0; i < 5; i++)
            {
                creditCategoryData.Add(new DomainCreditCategory { Id = Guid.NewGuid().ToString(), CreationDateUTC = DateTime.UtcNow, Title = $"Title{i}", SubTitle = $"SubTitle{i}" });
            }

            var qCreditCategoryData = creditCategoryData.AsQueryable();

            var mockCreditCategoriesSet = new Mock<DbSet<DomainCreditCategory>>();
            mockCreditCategoriesSet.As<IQueryable<DomainCreditCategory>>().Setup(m => m.Provider).Returns(qCreditCategoryData.Provider);
            mockCreditCategoriesSet.As<IQueryable<DomainCreditCategory>>().Setup(m => m.Expression).Returns(qCreditCategoryData.Expression);
            mockCreditCategoriesSet.As<IQueryable<DomainCreditCategory>>().Setup(m => m.ElementType).Returns(qCreditCategoryData.ElementType);
            mockCreditCategoriesSet.As<IQueryable<DomainCreditCategory>>().Setup(m => m.GetEnumerator()).Returns(qCreditCategoryData.GetEnumerator());

            mockDatabaseContext.Setup(c => c.CreditCategories).Returns(mockCreditCategoriesSet.Object);
            #endregion

            #region Mock Credits
            var creditData = new List<DomainCredit>();
            for (int i = 0; i < 25; i++)
            {
                string creditCategoryIdFK;

                if (i < 5)
                    creditCategoryIdFK = creditCategoryData[0].Id;
                else if(i < 10)
                    creditCategoryIdFK = creditCategoryData[1].Id;
                else if (i < 15)
                    creditCategoryIdFK = creditCategoryData[2].Id;
                else if (i < 20)
                    creditCategoryIdFK = creditCategoryData[3].Id;
                else
                    creditCategoryIdFK = creditCategoryData[4].Id;

                creditData.Add(new DomainCredit { Id = Guid.NewGuid().ToString(), CreationDateUTC = DateTime.UtcNow, Title = $"Title{i}", SubTitle = $"SubTitle{i}", CreditCategoryFK = creditCategoryIdFK, 
                    CreditCategory = creditCategoryData.First(cc => cc.Id == creditCategoryIdFK)});
            }

            var qCreditData = creditData.AsQueryable();

            var mockCreditsSet = new Mock<DbSet<DomainCredit>>();
            mockCreditsSet.As<IQueryable<DomainCredit>>().Setup(m => m.Provider).Returns(qCreditData.Provider);
            mockCreditsSet.As<IQueryable<DomainCredit>>().Setup(m => m.Expression).Returns(qCreditData.Expression);
            mockCreditsSet.As<IQueryable<DomainCredit>>().Setup(m => m.ElementType).Returns(qCreditData.ElementType);
            mockCreditsSet.As<IQueryable<DomainCredit>>().Setup(m => m.GetEnumerator()).Returns(qCreditData.GetEnumerator());

            mockDatabaseContext.Setup(c => c.Credits).Returns(mockCreditsSet.Object);
            #endregion



            return mockDatabaseContext;
        }
    }
}
