using MSS.Application.Infrastructure.Persistence;
using System.Linq;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails
{
    public sealed class GetUserAccountDetailQuery : IGetUserAccountDetailQuery
    {
        private readonly IUserAccountRepository _repository;

        public GetUserAccountDetailQuery(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public UserAccountDetailModel Execute(string email)
        {
            return _repository.GetAll()
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
    }
}
