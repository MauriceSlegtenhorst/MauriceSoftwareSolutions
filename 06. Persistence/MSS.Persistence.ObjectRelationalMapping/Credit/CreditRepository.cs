using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;

using MSS.Application.Infrastructure.Persistence;
using ObjectRelationalMapping.Shared;

namespace ObjectRelationalMapping.Credit
{
    public sealed class CreditRepository : Repository<DomainCredit>, ICreditRepository
    {
        public CreditRepository(IDatabaseContext database) : base(database) { }
    }
}
