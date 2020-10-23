using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory
{
    public sealed class UserAccountFactory : IUserAccountFactory
    {
        public DomainUserAccount Create(
            string email,
            string firstName = null,
            string lastName = null,
            string affix = null,
            string userName = null) => new DomainUserAccount
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Affix = affix,
                UserName = userName
            };
    }
}
