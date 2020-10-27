using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Domain.Concrete.DatabaseEntities.Identity;
using System.Threading.Tasks;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using System.Text;
using System.Collections.Generic;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.LogIn
{
    public class LogInQuery : ILogInQuery
    {
        private const string ErrorsKeepComingMessage = "If you keep receiving error please fill in our customer support form. Thank you in advance!";

        private readonly IQueryResultFactory _resultFactory;
        private readonly SignInManager<DomainUserAccount> _signInManager;

        public LogInQuery(
            IQueryResultFactory resultFactory,
            SignInManager<DomainUserAccount> signInManager)
        {
            _resultFactory = resultFactory;
            _signInManager = signInManager;
        }

        public async Task<QueryResult<SessionAuthenticationToken>> Execute(LogInModel logInModel)
        {
            if (logInModel == null)
                return _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[]
                    {
                        "No authenthication info was received.",
                        ErrorsKeepComingMessage
                    });

            var signInResult = await _signInManager.PasswordSignInAsync(logInModel.Username, logInModel.Password, logInModel.IsPersistent, true);

            if (signInResult.Succeeded == false)
            {
                var errorMessages = new List<string>();
                errorMessages.Add("Login has failed because of the following reasons:");

                if (signInResult.IsLockedOut)
                    errorMessages.Add("- You are locked out.");

                if (signInResult.IsNotAllowed)
                    errorMessages.Add("- You are not allowed to log in.");

                if (!signInResult.IsLockedOut && !signInResult.IsNotAllowed)
                    errorMessages.Add("- The provided credentials are invalid.");

                errorMessages.Add(ErrorsKeepComingMessage);

                return _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: errorMessages.ToArray());
            }


        }
    }
}
