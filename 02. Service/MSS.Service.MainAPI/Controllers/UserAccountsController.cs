using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails;
using MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using MSS.Domain.Concrete.EntityAttributes;
using System;
using System.Collections.Generic;
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
        public IEnumerable<UserAccountsListItemModel> GetList()
        {
            return _listQuery.Execute();
        }

        [Authorize]
        [HttpPut]
        public QueryResult<UserAccountDetailModel> Get()
        {
            return _detailQuery.Execute(_contextAccessor.HttpContext.User);
        }

        [HttpPut]
        public async Task<CommandResult> Create([FromBody] CreateUserAccountModel account)
        {
            return await _createCommand.Execute(account, CancellationToken.None);
        }
    }
}
