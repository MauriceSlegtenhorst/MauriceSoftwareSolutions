using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface IUserAccountRepository : IRepository<DomainUserAccount> { }
}
