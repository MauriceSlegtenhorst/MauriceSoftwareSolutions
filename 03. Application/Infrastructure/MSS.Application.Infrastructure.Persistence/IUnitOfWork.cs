using System.Threading;
using System.Threading.Tasks;

namespace MSS.Application.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync(ref CancellationToken cancellationToken);
    }
}
