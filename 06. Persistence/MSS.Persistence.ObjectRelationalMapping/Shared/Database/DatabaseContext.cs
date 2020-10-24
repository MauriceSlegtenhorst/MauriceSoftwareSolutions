using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;
using DomainCredit = MSS.Domain.Concrete.DatabaseEntities.Credit.Credit;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseEntities.Credit.CreditCategory;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ObjectRelationalMapping.Credit;
using ObjectRelationalMapping.UserAccount;
using System.Threading;
using MSS.Domain.Common.Interfaces;
using ObjectRelationalMapping.Seed;
using System;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ObjectRelationalMapping.Shared.Database
{
    public sealed class DatabaseContext : IdentityDbContext<DomainUserAccount>, IDatabaseContext
    {
        private readonly ILogger<DatabaseContext> _logger;

        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions, ILogger<DatabaseContext> logger) 
            : base(dbContextOptions) 
        {
            _logger = logger;
        }

        public DbSet<DomainUserAccount> UserAccounts { get; set; }
        public DbSet<DomainCredit> Credits { get; set; }
        public DbSet<DomainCreditCategory> CreditCategories { get; set; }

        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        /// <remarks>Please notify the presentation layer in case of an exception. DO NOT show details about the database!</remarks>
        /// <exception cref="DbUpdateException">Thrown when an error is encountered while saving to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">thrown when a concurrency violation is encountered while saving to the database. 
        /// A concurrency violation occurs when an unexpected number of rows are affected during save.
        /// This is usually because the data in the database has been modified since it was loaded into memory.</exception>
        /// <returns>If succeded returns the number of affected entries. Else rethrows the occured exception</returns>
        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            int affectedEntriesCount;

            try
            {
                affectedEntriesCount = await SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "DbUpdateConcurrencyException occured while trying to SaveChangesAsync");

                throw;
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError(ex, "DbUpdateException occured while trying to SaveChangesAsync");

                throw;
            }

            return affectedEntriesCount;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserAccountConfiguration());
            builder.ApplyConfiguration(new CreditConfiguration());
            builder.ApplyConfiguration(new CreditCategoryConfiguration());

            DatabaseSeeder.SeedDatabase(builder);
        }
    }
}
