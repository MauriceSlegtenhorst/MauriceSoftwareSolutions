using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails
{
    public interface IGetUserAccountDetailQuery
    {
        Task<Tuple<int,QueryResult<UserAccountDetailModel>>> Execute(ClaimsPrincipal claimsPrincipal);
    }
}