using MSS.Domain.Concrete.DatabaseEntities.Identity;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.Factory
{
    public interface ITokenFactory
    {
        SessionAuthenticationToken Create();
    }
}