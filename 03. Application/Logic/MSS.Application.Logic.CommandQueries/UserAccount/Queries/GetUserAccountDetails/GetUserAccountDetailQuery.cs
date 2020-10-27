using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using MSS.Application.Infrastructure.Persistence;
using System.Linq;
using System.Security.Claims;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using System;
using Microsoft.Extensions.Logging;
using System.Text;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails
{
    public sealed class GetUserAccountDetailQuery : IGetUserAccountDetailQuery
    {
        private const string SORRY = "Sorry for the inconvenience.";

        private readonly ILogger<GetUserAccountDetailQuery> _logger;
        private readonly IUserAccountRepository _repository;
        private readonly IQueryResultFactory _resultFactory;
        private readonly SignInManager<DomainUserAccount> _signInManager;

        public GetUserAccountDetailQuery(
            ILogger<GetUserAccountDetailQuery> logger,
            IUserAccountRepository repository,
            IQueryResultFactory resultFactory,
            SignInManager<DomainUserAccount> signInManager)
        {
            _logger = logger;
            _repository = repository;
            _resultFactory = resultFactory;
            _signInManager = signInManager;
        }

        public QueryResult<UserAccountDetailModel> Execute(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal == null)
                return _resultFactory.Create<UserAccountDetailModel>(
                 isSucceded: false,
                 resultItem: null,
                 messages: new string[]
                 {
                    "Your access token is invalid and or empty. Please try to login again.",
                    SORRY
                 });

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Identity name: {claimsPrincipal.Identity?.Name}");
            stringBuilder.AppendLine($"Is authenticated: {claimsPrincipal.Identity?.IsAuthenticated}");

            if (claimsPrincipal.Claims?.Any() == true)
            {
                stringBuilder.AppendLine("Claims:");
                foreach (var claim in claimsPrincipal.Claims)
                {
                    stringBuilder.AppendLine($"Issuer: {claim.Issuer}, Type: {claim.Type}, Value type: {claim.ValueType}, Value: {claim.Value}");
                }
            }

            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            if (String.IsNullOrEmpty(email))
            {
                stringBuilder.Insert(0, "WARNING: email could not be extracted from the ClaimsPrincipal object.\n");
                _logger.LogWarning(stringBuilder.ToString());

                return _resultFactory.Create<UserAccountDetailModel>(
                isSucceded: false,
                resultItem: null,
                messages: new string[]
                {
                    "Email could not be extracted from your request. We could not identify you and therefor not return your details",
                    SORRY
                });
            }

            UserAccountDetailModel accountDetailModel;

            try
            {
                accountDetailModel = _repository.GetAll()
                .Where(account => account.Email == email)
                .Select(account => new UserAccountDetailModel
                {
                    UserName = account.UserName,
                    FirstName = account.FirstName,
                    Affix = account.Affix,
                    LastName = account.LastName,
                    PhoneNumber = account.PhoneNumber
                })
                .Single();
            }
            catch (ArgumentNullException ex)
            {
                stringBuilder.Insert(0, "ERROR: ArgumentNullException was thrown and catched.\n");
                _logger.LogError(ex, stringBuilder.ToString());

                return _resultFactory.Create<UserAccountDetailModel>(
                isSucceded: false,
                resultItem: null,
                messages: new string[] 
                {
                    "No account was found."
                });
            }
            catch (InvalidOperationException ex)
            {
                stringBuilder.Insert(0, "ERROR: InvalidOperationException was thrown and catched.\n");
                _logger.LogError(ex, stringBuilder.ToString());

                return _resultFactory.Create<UserAccountDetailModel>(
                isSucceded: false,
                resultItem: null,
                messages: new string[]
                {
                    "More than one account was found. This problem has been reported and wil be fixed soon.",
                    SORRY
                });
            }
            catch (Exception ex)
            {
                stringBuilder.Insert(0, "ERROR: Exception was thrown and catched.\n");
                _logger.LogError(ex, stringBuilder.ToString());

                return _resultFactory.Create<UserAccountDetailModel>(
                isSucceded: false,
                resultItem: null,
                messages: new string[]
                {
                    "A unknown error has occured and has been logged.",
                    SORRY
                });
            }

            return _resultFactory.Create(
                isSucceded: true,
                resultItem: accountDetailModel);
        }
    }
}
