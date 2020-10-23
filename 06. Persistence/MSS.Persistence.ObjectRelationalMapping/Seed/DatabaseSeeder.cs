using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;
using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;

using Microsoft.EntityFrameworkCore;
using MSS.Persistence.ObjectRelationalMapping.Credit;
using MSS.Persistence.ObjectRelationalMapping.Seed;
using MSS.Persistence.ObjectRelationalMapping.UserAccount;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;

namespace ObjectRelationalMapping.Seed
{
    internal sealed class DatabaseSeeder
    {
        private static DomainUserAccount[] _userAccounts;
        private static IdentityRole[] _identityRoles;

        private DatabaseSeeder() { }

        internal static void SeedDatabase(ModelBuilder builder)
        {
            SeedUserAccounts(builder);
            SeedCredits(builder);
            SeedIdentityRoles(builder);
            SeedIdentityUserRoles(builder);
        }

        /// <exception cref="NullReferenceException">Thrown when the enviroment variable was not found. This results in an empty or null string variable which is not allowed.</exception>
        private static void SeedIdentityUserRoles(ModelBuilder builder)
        {
            if (_userAccounts == null || _userAccounts.Length == 0)
                throw new NullReferenceException($"{nameof(_userAccounts)} was empty or null");

            if (_identityRoles == null || _identityRoles.Length < Enum.GetNames(typeof(Roles)).Length)
                throw new NullReferenceException($"{nameof(_userAccounts)} was empty, not containing all roles or null");

            builder.Entity<IdentityUserRole<string>>().HasData(IdentityUserRoleSeedData.Build(_userAccounts, _identityRoles));
        }

        private static void SeedIdentityRoles(ModelBuilder builder)
        {
            _identityRoles = IdentityRoleSeedData.Build();

            builder.Entity<IdentityRole>().HasData(_identityRoles);
        }

        /// <exception cref="NullReferenceException">Thrown when the enviroment variable was not found. This results in an empty or null string variable which is not allowed.</exception>
        private static void SeedUserAccounts(ModelBuilder builder)
        {
            string password = Environment.GetEnvironmentVariable("MSSAccountPassword");

            if(String.IsNullOrEmpty(password))
                throw new NullReferenceException("password = null or empty");

            _userAccounts = UserAccountSeedData.Build(password);

            builder.Entity<DomainUserAccount>().HasData(_userAccounts);
        }

        private static void SeedCredits(ModelBuilder builder)
        {
            var creditCategories = CreditCategorySeedData.Build();
            var credits = CreditSeedData.Build();

            credits[0].CreditCategoryFK = creditCategories[0].Id;
            credits[1].CreditCategoryFK = creditCategories[1].Id;
            credits[2].CreditCategoryFK = creditCategories[1].Id;
            credits[3].CreditCategoryFK = creditCategories[1].Id;

            _ = builder.Entity<DomainCreditCategory>().HasData(creditCategories);
            _ = builder.Entity<DomainCredit>().HasData(credits);
        }
    }
}
