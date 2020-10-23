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

        public Task<int> SaveAsync(ref CancellationToken cancellationToken)
        {
            return _database.SaveAsync(ref cancellationToken);
        }
    }
}
