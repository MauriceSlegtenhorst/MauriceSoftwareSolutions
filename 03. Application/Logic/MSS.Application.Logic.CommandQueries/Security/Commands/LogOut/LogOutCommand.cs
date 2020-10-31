using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MSS.Application.Logic.CommandQueries.Security.Commands.LogOut
{
    public sealed class LogOutCommand : ILogOutCommand
    {
        private const string SORRY = "Sorry for the inconvenience.";

        private readonly SignInManager<DomainUserAccount> _signInManager;
        private readonly ICommandResultFactory _resultFactory;
        private readonly ILogger<LogOutCommand> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public LogOutCommand(
            SignInManager<DomainUserAccount> signInManager,
            ICommandResultFactory resultFactory,
            ILogger<LogOutCommand> logger,
            IHttpContextAccessor httpContext)
        {
            _signInManager = signInManager;
            _resultFactory = resultFactory;
            _logger = logger;
            _httpContext = httpContext;
        }

        public async Task<Tuple<int, CommandResult>> Execute()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {

                // TODO lof which user could not logout
                _logger.LogError(ex, $"Could not log out user: {_httpContext.HttpContext.User.FindFirst(ClaimTypes.Name)}");

                return new Tuple<int, CommandResult>(400, _resultFactory.Create(
                 isSucceded: false,
                 messages: new string[]
                 {
                    "Could not sign you out:(",
                    SORRY
                 }));
            }

            return new Tuple<int, CommandResult>(200, _resultFactory.Create(
                 isSucceded: true,
                 messages: new string[]
                 {
                    "You are signed out. Have a nice day!"
                 }));
        }
    }
}
