using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface IRepository<TEntity>
    {
        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken);

        public Task<TEntity> GetAsync(string id, CancellationToken cancellationToken);

        public IQueryable<TEntity> GetAllAsync();

        public void Remove(TEntity entity);
    }
}
