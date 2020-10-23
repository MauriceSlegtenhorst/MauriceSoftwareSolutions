using System.Collections.Generic;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList
{
    public interface IGetUserAccountsListQuery
    {
        List<UserAccountsListItemModel> Execute();
    }
}