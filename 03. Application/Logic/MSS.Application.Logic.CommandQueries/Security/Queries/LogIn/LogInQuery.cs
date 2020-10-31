using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Domain.Concrete.DatabaseEntities.Identity;
using System.Threading.Tasks;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using System.Text;
using System.Collections.Generic;
using MSS.Application.Logic.CommandQueries.Security.Queries.Factory;
using System;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.LogIn
{
    public class LogInQuery : ILogInQuery
    {
        private const string ErrorsKeepComingMessage = "If you keep receiving this error please fill in our customer support form. Thank you in advance!";

        private readonly ITokenFactory _tokenFactory;
        private readonly IQueryResultFactory _resultFactory;
        private readonly SignInManager<DomainUserAccount> _signInManager;

        public LogInQuery(
            ITokenFactory tokenFactory,
            IQueryResultFactory resultFactory,
            SignInManager<DomainUserAccount> signInManager)
        {
            _tokenFactory = tokenFactory;
            _resultFactory = resultFactory;
            _signInManager = signInManager;
        }

        public async Task<Tuple<int, QueryResult<SessionAuthenticationToken>>> Execute(LogInModel logInModel)
        {
            if (logInModel == null)
                return new Tuple<int, QueryResult<SessionAuthenticationToken>>(400, _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[]
                    {
                        "No authenthication info was received.",
                        ErrorsKeepComingMessage
                    }));

            var user = await _signInManager.UserManager.FindByNameAsync(logInModel.Username);

            SignInResult signInResult;

            try
            {
                signInResult = await _signInManager.PasswordSignInAsync(logInModel.Username, logInModel.Password, logInModel.IsPersistent, true);
            }
            catch
            {
                return new Tuple<int, QueryResult<SessionAuthenticationToken>>(500, _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[] { "Cannot log in due to server issues. This might be resolved in some time.", ErrorsKeepComingMessage }));
            }

            if (signInResult.Succeeded == false)
            {
                var errorMessages = new List<string>
                {
                    "Login has failed because of the following reasons:"
                };

                if (signInResult.IsLockedOut)
                {
                    var endDate = await _signInManager.UserManager.GetLockoutEndDateAsync(user);
                    errorMessages.Add($"- You are locked out until {endDate.Value.ToLocalTime().DateTime}.");
                }

                if (signInResult.IsNotAllowed)
                    errorMessages.Add("- You are not allowed to log in.");

                if (!signInResult.IsLockedOut && !signInResult.IsNotAllowed)
                    errorMessages.Add("- The provided credentials are invalid.");

                errorMessages.Add(ErrorsKeepComingMessage);

                return new Tuple<int, QueryResult<SessionAuthenticationToken>>(401, _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: errorMessages.ToArray()));
            }

            // Why do we actually need this? It is not even saved/persisted.
            SessionAuthenticationToken sessionToken;

            try
            {
                sessionToken = await _tokenFactory.Create(logInModel.Username, logInModel.IsPersistent);
            }
            catch (ArgumentException)
            {
                return new Tuple<int, QueryResult<SessionAuthenticationToken>>(500, _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[] { "Token could not be generated. The provided username is invalid", ErrorsKeepComingMessage }));
            }
            catch(NullReferenceException)
            {
                return new Tuple<int, QueryResult<SessionAuthenticationToken>>(500, _resultFactory.Create<SessionAuthenticationToken>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[] { "Token could not be generated. Could not find anybody with this username", ErrorsKeepComingMessage }));
            }

            return new Tuple<int, QueryResult<SessionAuthenticationToken>>(200, _resultFactory.Create(
                    isSucceded: true,
                    resultItem: sessionToken,
                    messages: new string[] { $"Login for {logInModel.Username} succeded. Your session ends on {DateTime.Now.AddMinutes(user.SessionTimeMinutes)}.", "Enjoy!"}));
        }
    }
}
