using Microsoft.EntityFrameworkCore;
using MSS.Application.Infrastructure.Persistence;
using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountsList
{
    public sealed class GetUserAccountsListQuery : IGetUserAccountsListQuery
    {
        private readonly IQueryResultFactory _resultFactory;
        private readonly IUserAccountRepository _repository;

        public GetUserAccountsListQuery(IQueryResultFactory resultFactory, IUserAccountRepository repository)
        {
            _resultFactory = resultFactory;
            _repository = repository;
        }

        public async Task<Tuple<int, QueryResult<List<UserAccountsListItemModel>>>> Execute()
        {
            List<UserAccountsListItemModel> userAccounts = null;

            try
            {
                var userAccountsQuery = _repository.GetAll().Select(userAccount => new UserAccountsListItemModel
                {
                    Email = userAccount.Email,
                    FirstName = userAccount.FirstName,
                    Affix = userAccount.Affix,
                    LastName = userAccount.LastName
                }).ToListAsync();

                userAccounts = await userAccountsQuery;
            }
            catch (ArgumentNullException)
            {
                return new Tuple<int, QueryResult<List<UserAccountsListItemModel>>>(500, _resultFactory.Create<List<UserAccountsListItemModel>>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[] { "Could not find anything. Contact an employee please." }));
            }
            
            if(userAccounts == null)
            {
                return new Tuple<int, QueryResult<List<UserAccountsListItemModel>>>(500, _resultFactory.Create<List<UserAccountsListItemModel>>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[] { "Could not find anything. Contact an employee please." }));
            }

            if(userAccounts.Any() == false)
            {
                return new Tuple<int, QueryResult<List<UserAccountsListItemModel>>>(500, _resultFactory.Create<List<UserAccountsListItemModel>>(
                    isSucceded: false,
                    resultItem: null,
                    messages: new string[] { "Could not find anything. Contact an employee please." }));
            }

            return new Tuple<int, QueryResult<List<UserAccountsListItemModel>>>(200, _resultFactory.Create(
                isSucceded: true,
                resultItem: userAccounts));
        }
    }
}
