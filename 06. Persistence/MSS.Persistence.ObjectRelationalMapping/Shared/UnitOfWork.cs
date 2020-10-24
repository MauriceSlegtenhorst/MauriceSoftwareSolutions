using MSS.Application.Infrastructure.Persistence;
using ObjectRelationalMapping.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Persistence.ObjectRelationalMapping.Shared
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _database;

        public UnitOfWork(IDatabaseContext database)
        {
            _database = database;
        }

        /// <remarks>Please notify the presentation layer in case of an exception. DO NOT show details about the database!</remarks>
        /// <exception cref="DbUpdateException">Thrown when an error is encountered while saving to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">thrown when a concurrency violation is encountered while saving to the database. 
        /// A concurrency violation occurs when an unexpected number of rows are affected during save. 
        /// This is usually because the data in the database has been modified since it was loaded into memory.</exception>
        /// <returns>If succeded returns the number of affected entries. Else throws the occured exception</returns>
        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _database.SaveAsync(cancellationToken);
        }
    }
}
