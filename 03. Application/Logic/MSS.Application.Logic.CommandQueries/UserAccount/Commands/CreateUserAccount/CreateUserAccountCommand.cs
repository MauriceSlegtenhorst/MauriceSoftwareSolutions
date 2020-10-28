﻿using Microsoft.AspNetCore.Identity;
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
        private const string ErrorsKeepComingMessage = "If you keep receiving this error please fill in our customer support form. Thank you in advance!";
        private const string ErrorTryAgainMessage = "Please check if you got any mail from us. If you did not receive mail from us, please try and fill in the form again.";

        private readonly IUserAccountRepository _repository;
        private readonly IUserAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandResultFactory _resultFactory;
        private readonly ILogger<CreateUserAccountCommand> _logger;

        public CreateUserAccountCommand(
            IUserAccountRepository repository,
            IUserAccountFactory accountFactory,
            IUnitOfWork unitOfWork,
            ICommandResultFactory resultFactory,
            ILogger<CreateUserAccountCommand> logger)
        {
            _repository = repository;
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
            _resultFactory = resultFactory;
            _logger = logger;
        }

        public async Task<Tuple<int,CommandResult>> Execute(CreateUserAccountModel model, CancellationToken cancellationToken)
        {
            var userAccount = _accountFactory.Create(
                email:              model.Email,
                sessionTimeMinutes: model.SessionTimeMinutes,
                firstName:          model.FirstName,
                affix:              model.Affix,
                lastName:           model.LastName,
                userName:           model.UserName,
                description:        model.Description);

            IdentityResult creationResult = await _repository.Add(userAccount, model.Password);

            // Handle creation errors
            if (creationResult.Succeeded == false)
            {
                _logger.LogError($"Creating an user account failed for user: {model.FirstName} {model.Affix?.ToString().Append(' ')}{model.LastName} with the email address {model.Email}.");

                for (int i = 1; i < creationResult.Errors.Count(); i++)
                {
                    int errorIndex = i - 1;
                    _logger.LogError($"Code: {creationResult.Errors.ElementAt(errorIndex).Code} Description: {creationResult.Errors.ElementAt(errorIndex).Description}.");
                }

                return new Tuple<int, CommandResult>(500, _resultFactory.Create(
                    isSucceded: false, 
                    messages: new string[]
                {
                    "Unfortunately an error occurred during the process of creating your account.",
                    ErrorTryAgainMessage,
                    ErrorsKeepComingMessage
                }));
            }

            int affectedEntriesCount;

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

            // Handle zero changes were made somehow... dafuq
            if (affectedEntriesCount == 0)
            {
                return new Tuple<int, CommandResult>(500, _resultFactory.Create(
                    isSucceded: false,
                    messages: new string[]
                    {
                        "Unfortunately somthing really weird went wrong. Zero entries were affected meaning nothing happened.",
                        ErrorTryAgainMessage,
                        ErrorsKeepComingMessage
                    }));
            }

            // Report success back to the caller with a CommandResult
            return new Tuple<int, CommandResult>(201, _resultFactory.Create(
                isSucceded: true, 
                messages: new string[]
                {
                    $"Saving your account succeded! Thank you for joining us {model.FirstName} {model.Affix?.ToString().Append(' ')}{model.LastName}.",
                    $"Please check your email {model.Email} and click the link to verify it is you and your email is real."
                }));
        }

        // Here to prevent duplicate code
        private Tuple<int, CommandResult> HandleSaveAsyncException(
            DbUpdateConcurrencyException concurrencyException = null,
            DbUpdateException updateException = null)
        {
            var ex = concurrencyException ?? updateException;

            if (ex == null)
                throw new ArgumentException("One of the two types of exceptions must be provided as an initialized object.");

            return new Tuple<int, CommandResult>(500, _resultFactory.Create(
                isSucceded: false, 
                messages: new string[]
                {
                    "Unfortunately an error occurred during the process of saving your account.",
                    ErrorTryAgainMessage,
                    ErrorsKeepComingMessage
                }));
        }
    }
}
