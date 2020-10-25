using System;
using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

namespace MSS.Application.Infrastructure.Persistence
{
    [Obsolete]
    public interface IUserAccountRepository : IRepository<DomainUserAccount> { }
}
