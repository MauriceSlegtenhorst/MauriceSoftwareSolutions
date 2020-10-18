using DomainCreditCategory = MSS.Domain.Concrete.DatabaseModels.Credit.CreditCategory;

using MSS.Application.Infrastructure.Persistence;
using System.Linq;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditCategoryRepository : IRepository<DomainCreditCategory>
    {
        public void Add(DomainCreditCategory entity)
        {
            throw new System.NotImplementedException();
        }

        public DomainCreditCategory Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<DomainCreditCategory> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(DomainCreditCategory entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
