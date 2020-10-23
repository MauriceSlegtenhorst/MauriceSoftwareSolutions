using Microsoft.EntityFrameworkCore;
using MSS.Application.Infrastructure.Persistence;
using MSS.Domain.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectRelationalMapping.Shared
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IDatabaseContext _databaseContext;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Add(entity);
        }

        public Task<TEntity> GetAsync(string id, CancellationToken cancellationToken)
        {
            return _databaseContext.Set<TEntity>().SingleAsync(entity => entity.Id == id, cancellationToken);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _databaseContext.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Remove(entity);
        }
    }
}
