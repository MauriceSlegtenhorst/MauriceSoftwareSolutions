using MSS.Application.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList
{
    public sealed class GetUserAccountsListQuery : IGetUserAccountsListQuery
    {
        private readonly IUserAccountRepository _repository;

        public GetUserAccountsListQuery(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public List<UserAccountsListItemModel> Execute()
        {
            var userAccounts = _repository.GetAll().Select(userAccount => new UserAccountsListItemModel
            {
                Email = userAccount.Email,
                FirstName = userAccount.FirstName,
                Affix = userAccount.Affix,
                LastName = userAccount.LastName
            });

            return userAccounts.ToList();
        }
    }
}
