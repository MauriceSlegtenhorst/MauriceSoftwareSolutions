using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList
{
    public interface IGetUserAccountsListQuery
    {
        Task<Tuple<int,QueryResult<List<UserAccountsListItemModel>>>> Execute();
    }
}