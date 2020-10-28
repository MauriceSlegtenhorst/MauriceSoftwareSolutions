using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using System;

namespace MSS.Persistence.ObjectRelationalMapping.UserAccount
{
    internal sealed class UserAccountSeedData
    {
        private const int SESSION_TIME_MINUTES = 10;
        private const string AVATAR_LINK = "https://respondsystems.com/wp-content/uploads/2015/12/RSI_generic_avatar-150x150.jpg";
        private const string HTML_DESCRIPTION = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Orci sagittis eu volutpat odio facilisis " +
            "mauris sit amet. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Faucibus a pellentesque sit amet porttitor eget dolor morbi. Libero justo laoreet sit amet cursus. Varius vel " +
            "pharetra vel turpis nunc eget lorem dolor. Adipiscing elit ut aliquam purus. Enim sed faucibus turpis in eu mi bibendum. Fames ac turpis egestas maecenas pharetra. Sed turpis tincidunt id aliquet. " +
            "Lorem ipsum dolor sit amet consectetur adipiscing. Quam quisque id diam vel quam elementum pulvinar.</p><p>Eu augue ut lectus arcu bibendum at varius vel pharetra. Sapien faucibus et molestie ac " +
            "feugiat sed lectus. Id neque aliquam vestibulum morbi blandit cursus risus at ultrices. Nunc non blandit massa enim nec dui nunc. Vel pharetra vel turpis nunc eget lorem. Enim nulla aliquet porttitor " +
            "lacus luctus accumsan tortor posuere. Massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada. Est ante in nibh mauris cursus mattis molestie. Tristique et egestas quis ipsum suspendisse " +
            "ultrices gravida dictum fusce. In ornare quam viverra orci sagittis eu volutpat. Ultrices sagittis orci a scelerisque purus. Lacus laoreet non curabitur gravida arcu ac. Amet mattis vulputate enim nulla " +
            "aliquet porttitor lacus. Fermentum posuere urna nec tincidunt praesent semper. Netus et malesuada fames ac turpis egestas maecenas pharetra. Tellus cras adipiscing enim eu turpis egestas.</p>";

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
                    PhoneNumber = "0645377536",
                    SessionTimeMinutes = SESSION_TIME_MINUTES,
                    HTMLDescription = HTML_DESCRIPTION,
                    AvatarLink = AVATAR_LINK
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
                    PhoneNumber = "0645377536",
                    SessionTimeMinutes = SESSION_TIME_MINUTES,
                    HTMLDescription = HTML_DESCRIPTION,
                    AvatarLink = AVATAR_LINK
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
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10"),
                    SessionTimeMinutes = SESSION_TIME_MINUTES,
                    HTMLDescription = HTML_DESCRIPTION,
                    AvatarLink = AVATAR_LINK
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
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10"),
                    SessionTimeMinutes = SESSION_TIME_MINUTES,
                    HTMLDescription = HTML_DESCRIPTION,
                    AvatarLink = AVATAR_LINK
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
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10"),
                    SessionTimeMinutes = SESSION_TIME_MINUTES,
                    HTMLDescription = HTML_DESCRIPTION,
                    AvatarLink = AVATAR_LINK
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
                    PhoneNumber = "06" + new Random().Next(0, 999999).ToString("D10"),
                    SessionTimeMinutes = SESSION_TIME_MINUTES,
                    HTMLDescription = HTML_DESCRIPTION,
                    AvatarLink = AVATAR_LINK
                }
            };
        }
    }
}
