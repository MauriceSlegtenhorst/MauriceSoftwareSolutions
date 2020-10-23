using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

using Microsoft.AspNetCore.Identity;
using MSS.Application.Infrastructure.Persistence;
using MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount
{
    public sealed class CreateUserAccountCommand
    {
        private readonly IUserAccountRepository _repository;
        private readonly IUserAccountFactory _accountFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<DomainUserAccount> _userManager;

        public CreateUserAccountCommand(
            IUserAccountRepository repository,
            IUserAccountFactory accountFactory, 
            IUnitOfWork unitOfWork,
            UserManager<DomainUserAccount> userManager)
        {
            _repository = repository;
            _accountFactory = accountFactory;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<string[]> Execute(CreateUserAccountModel model, ref CancellationToken cancellationToken)
        {
            var userAccount = _accountFactory.Create(
                model.Email,
                model.FirstName,
                model.LastName,
                model.Affix,
                model.UserName);

            var result = await _userManager.CreateAsync(userAccount, model.Password);

            if

            return await _unitOfWork.SaveAsync(ref cancellationToken);
        }
    }
}
