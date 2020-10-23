using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        Task<TEntity> GetAsync(string id, CancellationToken cancellationToken);

        IQueryable<TEntity> GetAll();

        void Remove(TEntity entity);
    }
}
