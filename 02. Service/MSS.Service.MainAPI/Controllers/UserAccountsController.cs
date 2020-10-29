using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using MSS.Domain.Concrete.EntityAttributes;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Service.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountsController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IGetUserAccountsListQuery _listQuery;
        private readonly IGetUserAccountDetailQuery _detailQuery;
        private readonly ICreateUserAccountCommand _createCommand;

        public UserAccountsController(
            IHttpContextAccessor contextAccessor,
            IGetUserAccountsListQuery listQuery,
            IGetUserAccountDetailQuery detailQuery,
            ICreateUserAccountCommand createCommand)
        {
            _contextAccessor = contextAccessor;
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
        }

        [EnumAuthorize(Roles.Administrator | Roles.PrivilegedEmployee | Roles.Employee)]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var queryResultTuple = await _listQuery.Execute();
            return StatusCode(queryResultTuple.Item1, queryResultTuple.Item2);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Get()
        {
            var queryResultTuple = await _detailQuery.Execute(_contextAccessor.HttpContext.User);
            return StatusCode(queryResultTuple.Item1, queryResultTuple.Item2);
        }

        [HttpPut]
        public async Task<IActionResult> Create([FromBody] CreateUserAccountModel account)
        {
            var commandResultTuple = await _createCommand.Execute(account, CancellationToken.None);
            return StatusCode(commandResultTuple.Item1, commandResultTuple.Item2);
        }
    }
}
