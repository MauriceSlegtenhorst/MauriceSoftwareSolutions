using DomainUserAccount = MSS.Domain.Concrete.DatabaseModels.UserAccount;

using MSS.Application.Infrastructure.Persistence;
using System.Linq;

namespace ObjectRelationalMapping.UserAccount
{
    public sealed class UserAccountRepository : IRepository<DomainUserAccount>
    {
        public void Add(DomainUserAccount entity)
        {
            
        }

        public DomainUserAccount Get(int id)
        {
            
        }

        public IQueryable<DomainUserAccount> GetAll()
        {
            
        }

        public void Remove(DomainUserAccount entity)
        {

        }
    }
}
