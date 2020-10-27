using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface IUserAccountRepository
    {
        Task<IdentityResult> Add(DomainUserAccount entity, string password);

        IQueryable<DomainUserAccount> GetAll();

        Task<DomainUserAccount> GetAsync(string email, CancellationToken cancellationToken);

        Task<IdentityResult> Remove(DomainUserAccount entity);
    }
}
