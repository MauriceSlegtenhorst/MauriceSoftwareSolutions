using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using MSS.Application.Infrastructure.Persistence;
using ObjectRelationalMapping.Shared;
using System;

namespace ObjectRelationalMapping.UserAccount
{
    [Obsolete]
    public sealed class UserAccountRepository : Repository<DomainUserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(IDatabaseContext database) : base(database) { }

        public void Add(DomainUserAccount entity, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
