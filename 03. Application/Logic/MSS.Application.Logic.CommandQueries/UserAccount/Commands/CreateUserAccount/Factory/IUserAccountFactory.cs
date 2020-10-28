using System;
using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory
{
    public interface IUserAccountFactory
    {
        DomainUserAccount Create(
            string email,
            int sessionTimeMinutes,
            string firstName,
            string affix,
            string lastName,
            string userName,
            string description);
    }
}