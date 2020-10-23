using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface ICreditRepository : IRepository<DomainCredit> { }
}
