﻿using DomainUserAccount = MSS.Domain.Concrete.DatabaseModels.UserAccount;
using DomainCredit = MSS.Domain.Concrete.DatabaseModels.Credit.Credit;
using DomainCreditCategory = MSS.Domain.Concrete.DatabaseModels.Credit.CreditCategory;

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
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
