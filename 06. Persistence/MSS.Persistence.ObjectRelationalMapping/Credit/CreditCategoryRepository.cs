using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

using ObjectRelationalMapping.Shared;
using MSS.Application.Infrastructure.Persistence;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditCategoryRepository : Repository<DomainCreditCategory>, ICreditCategoryRepository
    {
        public CreditCategoryRepository(IDatabaseContext database) : base(database) { }
    }
}
