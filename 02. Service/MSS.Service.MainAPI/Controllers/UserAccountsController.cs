using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;
using System.Collections.Generic;

namespace MSS.Service.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountsController : ControllerBase
    {
        private readonly IGetUserAccountsListQuery _listQuery;
        private readonly IGetUserAccountDetailQuery _detailQuery;

        public UserAccountsController(
            IGetUserAccountsListQuery listQuery,
            IGetUserAccountDetailQuery detailQuery)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
        }

        public IEnumerable<UserAccountsListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        public UserAccountDetailModel Get(string email)
        {
            return _detailQuery.Execute(email);
        }
    }
}
