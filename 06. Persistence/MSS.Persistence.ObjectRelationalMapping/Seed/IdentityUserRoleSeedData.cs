using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using System;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using System.Linq;

namespace MSS.Persistence.ObjectRelationalMapping.Seed
{
    internal sealed class IdentityUserRoleSeedData
    {
        private IdentityUserRoleSeedData() { }

        /// <exception cref="ArgumentException">Source or predicate is null.</exception>
        /// <exception cref="InvalidOperationException">No element satisfies the condition in predicate. -or- The source sequence is empty</exception>
        internal static IdentityUserRole<string>[] Build(DomainUserAccount[] userAccounts, IdentityRole[] identityRoles)
        {
            return new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles.First(role => role.Name == Enum.GetName(typeof(Roles), Roles.Administrator)).Id,
                    UserId = userAccounts.First(account => account.Email == "maurice.slegtenhorst@outlook.com").Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles.First(role => role.Name == Enum.GetName(typeof(Roles), Roles.Administrator)).Id,
                    UserId = userAccounts.First(account => account.Email == "mauricesoftwaresolution@outlook.com").Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles.First(role => role.Name == Enum.GetName(typeof(Roles), Roles.Administrator)).Id,
                    UserId = userAccounts.First(account => account.Email == "hanneke.slegtenhorst1@gmail.com").Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles.First(role => role.Name == Enum.GetName(typeof(Roles), Roles.PrivilegedEmployee)).Id,
                    UserId = userAccounts.First(account => account.Email == "privilegedemployee01@mss.nl").Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles.First(role => role.Name == Enum.GetName(typeof(Roles), Roles.Employee)).Id,
                    UserId = userAccounts.First(account => account.Email == "employee01@mss.nl").Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = identityRoles.First(role => role.Name == Enum.GetName(typeof(Roles), Roles.StandardUser)).Id,
                    UserId = userAccounts.First(account => account.Email == "standarduser01@mss.nl").Id
                }
            };
        }
    }
}
