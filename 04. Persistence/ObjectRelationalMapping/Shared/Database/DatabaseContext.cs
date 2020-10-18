using DomainUserAccount = MSS.Domain.Concrete.DatabaseModels.UserAccount;
using DomainCredit = MSS.Domain.Concrete.DatabaseModels.Credit.Credit;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseModels.Credit.CreditCategory;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ObjectRelationalMapping.Credit;
using ObjectRelationalMapping.UserAccount;
using System.Threading;
using MSS.Domain.Common.Interfaces;

namespace ObjectRelationalMapping.Shared.Database
{
    public sealed class DatabaseContext : IdentityDbContext<DomainUserAccount>, IDatabaseContext
    {
        public DbSet<DomainUserAccount> UserAccounts { get; set; }
        public DbSet<DomainCredit> Credits { get; set; }
        public DbSet<DomainCreditCategory> CreditCategories { get; set; }

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        /// <exception cref="DbUpdateException">Thrown when an error is encountered while saving to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">thrown when a concurrency violation is encountered while saving to the database. 
        /// A concurrency violation occurs when an unexpected number of rows are affected during save. 
        /// This is usually because the data in the database has been modified since it was loaded into memory.</exception>
        public Task SaveAsync(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserAccountConfiguration());
            builder.ApplyConfiguration(new CreditConfiguration());
            builder.ApplyConfiguration(new CreditCategoryConfiguration());
        }
    }
}
