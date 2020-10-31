using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.Security.Commands.LogOut;
using MSS.Application.Logic.CommandQueries.Security.Queries.LogIn;
using System;
using System.Threading.Tasks;

namespace MSS.Service.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogInQuery _logInQuery;
        private readonly ILogOutCommand _logOutCommand;

        public SecurityController(ILogInQuery logInQuery, ILogOutCommand logOutCommand)
        {
            _logInQuery = logInQuery;
            _logOutCommand = logOutCommand;
        }

        // Tested with postman
        [HttpPut(nameof(LogIn))]
        public async Task<IActionResult> LogIn([FromBody]LogInModel logInModel)
        {
            var queryTupleResult = await _logInQuery.Execute(logInModel);
            return StatusCode(queryTupleResult.Item1, queryTupleResult.Item2);
        }

        [Authorize]
        [HttpGet(nameof(LogOut))]
        public async Task<IActionResult> LogOut()
        {
            var commandTupleResult = await _logOutCommand.Execute();
            return StatusCode(commandTupleResult.Item1, commandTupleResult.Item2);
        }
    }
}
