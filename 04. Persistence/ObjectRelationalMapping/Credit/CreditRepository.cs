using DomainCredit = MSS.Domain.Concrete.DatabaseModels.Credit.Credit;

using MSS.Application.Infrastructure.Persistence;
using System.Linq;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditRepository : IRepository<DomainCredit>
    {
        public void Add(DomainCredit entity)
        {
            throw new System.NotImplementedException();
        }

        public DomainCredit Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<DomainCredit> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(DomainCredit entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
