using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Service.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountsController : ControllerBase
    {
        private readonly IGetUserAccountsListQuery _listQuery;
        private readonly IGetUserAccountDetailQuery _detailQuery;
        private readonly ICreateUserAccountCommand _createCommand;

        public UserAccountsController(
            IGetUserAccountsListQuery listQuery,
            IGetUserAccountDetailQuery detailQuery,
            ICreateUserAccountCommand createCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
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
        public async Task<IActionResult> Create([FromBody]CreateUserAccountModel account)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var result = await _createCommand.Execute(account, cancellationTokenSource.Token);

            return Ok();
        }

        //[HttpPut]
        //public IActionResult CancelCreate()
        //{

        //}
    }
}
