using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;

namespace MSS.Application.Logic.CommandQueries.Security.Commands.LogOut
{
    public sealed class LogOutCommand
    {
        private const string SORRY = "Sorry for the inconvenience.";

        private readonly SignInManager<DomainUserAccount> _signInManager;
        private readonly ICommandResultFactory _resultFactory;

        public LogOutCommand(
            SignInManager<DomainUserAccount> signInManager,
            ICommandResultFactory resultFactory)
        {
            _signInManager = signInManager;
            _resultFactory = resultFactory;
        }

        public async Task<Tuple<int, CommandResult>> Execute()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch
            {
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
