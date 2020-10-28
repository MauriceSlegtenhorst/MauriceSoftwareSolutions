using System;
using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory
{
    public sealed class UserAccountFactory : IUserAccountFactory
    {
        public DomainUserAccount Create(
            string email,
            int sessionTimeMinutes = 10,
            string firstName = null,
            string affix = null,
            string lastName = null,
            string userName = null,
            string description = null) => new DomainUserAccount
            {
                Email = email,
                SessionTimeMinutes = sessionTimeMinutes,
                FirstName = firstName,
                LastName = lastName,
                Affix = affix,
                UserName = userName ?? email,
                HTMLDescription = description
            };
    }
}
