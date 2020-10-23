using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface ICreditCategoryRepository : IRepository<DomainCreditCategory> { }
}
