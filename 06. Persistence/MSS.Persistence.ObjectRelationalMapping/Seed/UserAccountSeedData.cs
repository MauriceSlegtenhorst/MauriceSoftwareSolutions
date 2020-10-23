using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using System;

namespace MSS.Persistence.ObjectRelationalMapping.UserAccount
{
    internal sealed class UserAccountSeedData
    {
        private UserAccountSeedData() { }

        /// <exception cref="ArgumentException">Thrown when parameter password is null or empty</exception>
        internal static DomainUserAccount[] Build(string password)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException($"Parameter {nameof(password)} cannot be null or empty. It is needed to setup the user accounts");

            string passwordHash = new PasswordHasher<DomainUserAccount>().HashPassword(new DomainUserAccount(), password);

            return new DomainUserAccount[]
            {
                new DomainUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Maurice",
                    LastName = "Slegtenhorst",
                    Email = "maurice.slegtenhorst@outlook.com",
                    NormalizedEmail = "maurice.slegtenhorst@outlook.com".ToUpper(),
                    UserName = "maurice.slegtenhorst@outlook.com",
                    PasswordHash = passwordHash,
                    NormalizedUserName = "maurice.slegtenhorst@outlook.com".ToUpper(),
                    PhoneNumber = "0645377536"
                },
                new DomainUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Maurice",
                    LastName = "Slegtenhorst",
                    Email = "mauricesoftwaresolution@outlook.com",
                    NormalizedEmail = "mauricesoftwaresolution@outlook.com".ToUpper(),
                    UserName = "mauricesoftwaresolution@outlook.com",
                    PasswordHash = passwordHash,
                    NormalizedUserName = "mauricesoftwaresolution@outlook.com".ToUpper(),
                    PhoneNumber = "0645377536"
                },
                new DomainUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Hanneke",
                    LastName = "Slegtenhorst",
                    Email = "hanneke.slegtenhorst1@gmail.com",
                    NormalizedEmail = "hanneke.slegtenhorst1@gmail.com".ToUpper(),
                    UserName = "hanneke.slegtenhorst1@gmail.com",
                    PasswordHash = passwordHash,
                    NormalizedUserName = "hanneke.slegtenhorst1@gmail.com".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10")
                },
                new DomainUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "PrivilegedEmployee_01",
                    LastName = "None",
                    Email = "privilegedemployee01@mss.nl",
                    NormalizedEmail = "privilegedemployee01@mss.nl".ToUpper(),
                    UserName = "privilegedemployee01@mss.nl",
                    PasswordHash = passwordHash,
                    NormalizedUserName = "privilegedEmployee01@mss.nl".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10")
                },
                new DomainUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "Employee_01",
                    LastName = "None",
                    Email = "employee01@mss.nl",
                    NormalizedEmail = "employee01@mss.nl".ToUpper(),
                    UserName = "employee01@mss.nl",
                    PasswordHash = passwordHash,
                    NormalizedUserName = "Employee01@mss.nl".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10")
                },
                new DomainUserAccount
                {
                    Id = Guid.NewGuid().ToString(),
                    IsAdmitted = true,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    FirstName = "StandardUser_01",
                    LastName = "None",
                    Email = "standarduser01@mss.nl",
                    NormalizedEmail = "standarduser01@mss.nl".ToUpper(),
                    UserName = "standarduser01@mss.nl",
                    PasswordHash = passwordHash,
                    NormalizedUserName = "standarduser01@mss.nl".ToUpper(),
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10")
                }
            };
        }
    }
}
