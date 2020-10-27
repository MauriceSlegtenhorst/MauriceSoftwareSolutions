using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using MSS.Application.Infrastructure.Persistence;
using ObjectRelationalMapping.Shared;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Identity;

namespace ObjectRelationalMapping.UserAccount
{
    public sealed class UserAccountRepository : IUserAccountRepository
    {
        private readonly UserManager<DomainUserAccount> _userManager;

        public UserAccountRepository(IDatabaseContext database, UserManager<DomainUserAccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Add(DomainUserAccount entity, string password)
        {
            return await _userManager.CreateAsync(entity, password);
        }

        public IQueryable<DomainUserAccount> GetAll()
        {
            return _userManager.Users;
        }

        public async Task<DomainUserAccount> GetAsync(string email, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> Remove(DomainUserAccount entity)
        {
            return await _userManager.DeleteAsync(entity);
        }
    }
}
