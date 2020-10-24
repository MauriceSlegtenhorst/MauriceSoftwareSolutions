using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;
using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using MSS.Domain.Common.Interfaces;

namespace ObjectRelationalMapping.Shared
{
    public interface IDatabaseContext
    {
        DbSet<DomainUserAccount> UserAccounts { get; set; }
        DbSet<DomainCredit> Credits { get; set; }
        DbSet<DomainCreditCategory> CreditCategories { get;set; }

        DbSet<T> Set<T>() where T : class, IEntity;

        /// <exception cref="DbUpdateException">Thrown when an error is encountered while saving to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">Thrown when a concurrency violation is encountered while saving to the database. 
        /// A concurrency violation occurs when an unexpected number of rows are affected during save. 
        /// This is usually because the data in the database has been modified since it was loaded into memory.</exception>
        /// <returns>If succeded return a Task containing the number of affected entities. Else return a Task containing the occured exception</returns>
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
