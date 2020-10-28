using Microsoft.AspNetCore.Mvc;
using MSS.Application.Logic.CommandQueries.Security.Queries.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSS.Service.MainAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ILogInQuery _logInQuery;

        public SecurityController(ILogInQuery logInQuery)
        {
            _logInQuery = logInQuery;
        }

        [Route("login")]
        [HttpPut]
        public async Task<IActionResult> LogIn([FromBody]LogInModel logInModel)
        {
            var queryTupleResult = await _logInQuery.Execute(logInModel);
            return StatusCode(queryTupleResult.Item1, queryTupleResult.Item2);
        }
    }
}
