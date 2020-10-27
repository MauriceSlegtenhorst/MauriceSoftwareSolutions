using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Domain.Concrete.DatabaseEntities.Identity;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.LogIn
{
    public interface ILogInQuery
    {
        Task<QueryResult<SessionAuthenticationToken>> Execute(LogInModel logInModel);
    }
}