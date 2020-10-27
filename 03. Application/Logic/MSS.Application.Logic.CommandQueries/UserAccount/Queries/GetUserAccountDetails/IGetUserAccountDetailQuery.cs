using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using System.Security.Claims;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails
{
    public interface IGetUserAccountDetailQuery
    {
        QueryResult<UserAccountDetailModel> Execute(ClaimsPrincipal claimsPrincipal);
    }
}