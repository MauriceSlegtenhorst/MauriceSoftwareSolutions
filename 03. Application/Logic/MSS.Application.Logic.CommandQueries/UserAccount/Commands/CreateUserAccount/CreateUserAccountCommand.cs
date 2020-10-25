using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using MSS.Application.Infrastructure.Persistence;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory;
using System.Threading;
using System.Threading.Tasks;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount
{
    public sealed class CreateUserAccountCommand : ICreateUserAccountCommand
    {
        private const string ErrorsKeepComingMessage = "If you keep receiving error please fill in our customer support form. Thank you in advance!";
        private const string ErrorTryAgainMessage = "Please check if you got any mail from us. If you did not receive mail from us, please try and fill in the form again.";

        private readonly IUserAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandResultFactory _resultFactory;
        private readonly UserManager<DomainUserAccount> _userManager;
        private readonly ILogger<CreateUserAccountCommand> _logger;

        public CreateUserAccountCommand(
            IUserAccountFactory accountFactory,
            IUnitOfWork unitOfWork,
            ICommandResultFactory resultFactory,
            ILogger<CreateUserAccountCommand> logger,
            UserManager<DomainUserAccount> userManager)
        {
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
            _resultFactory = resultFactory;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<CommandResult> Execute(CreateUserAccountModel model, CancellationToken cancellationToken)
        {
            var userAccount = _accountFactory.Create(
                model.Email,
                model.FirstName,
                model.LastName,
                model.Affix,
                model.UserName);

            IdentityResult createResult = await _userManager.CreateAsync(userAccount, model.Password);

            // Handle creation errors
            if (createResult.Succeeded == false)
            {
                _logger.LogError($"Creating an user account failed for user: {model.FirstName} {model.Affix?.ToString().Append(' ')}{model.LastName} with the email address {model.Email}.");

                for (int i = 1; i < createResult.Errors.Count(); i++)
                {
                    int errorIndex = i - 1;
                    _logger.LogError($"Code: {createResult.Errors.ElementAt(errorIndex).Code} Description: {createResult.Errors.ElementAt(errorIndex).Description}.");
                }

                return _resultFactory.Create(false, new string[]
                {
                    "Unfortunately an error occurred during the process of creating your account.",
                    ErrorTryAgainMessage,
                    ErrorsKeepComingMessage
                });
            }

            int affectedEntriesCount = 0;

            // Try to save changes to the database
            try
            {
                affectedEntriesCount = await _unitOfWork.SaveAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return HandleSaveAsyncException(concurrencyException: ex);
            }
            catch (DbUpdateException ex)
            {
                return HandleSaveAsyncException(updateException: ex);
            }

            // Handle zero changes were made somehow
            if (affectedEntriesCount == 0)
            {
                return _resultFactory.Create(false, new string[]
                {
                    "Unfortunately somthing really weird went wrong. Zero entries were affected meaning nothing happened.",
                    ErrorTryAgainMessage,
                    ErrorsKeepComingMessage
                });
            }

            // Report success back to the caller with a CommandResult
            return _resultFactory.Create(true, new string[]
            {
                $"Saving your account succeded! Thank you for joining us {model.FirstName} {model.Affix?.ToString().Append(' ')}{model.LastName}.",
                $"Please check your email {model.Email} and click the link to verify it is you."
            });
        }

        private CommandResult HandleSaveAsyncException(
            DbUpdateConcurrencyException concurrencyException = null,
            DbUpdateException updateException = null)
        {
            var ex = concurrencyException ?? updateException;

            if (ex == null)
                throw new ArgumentException("One of the two types of exceptions must be provided as an initialized object.");

            return _resultFactory.Create(false, new string[]
            {
                "Unfortunately an error occurred during the process of saving your account.",
                ErrorTryAgainMessage,
                ErrorsKeepComingMessage
            },
            ex);
        }
    }
}
