using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [Authorize]
        [HttpGet]
        public IEnumerable<UserAccountsListItemModel> GetList()
        {
            return _listQuery.Execute();
        }

        [Authorize]
        [HttpPut]
        public UserAccountDetailModel Get([FromBody]string email)
        {
            return _detailQuery.Execute(email);
        }

        [HttpPut]
        public async Task<IActionResult>
    }
}
