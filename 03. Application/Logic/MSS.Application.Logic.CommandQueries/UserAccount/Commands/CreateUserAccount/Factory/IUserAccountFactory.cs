using DomainUserAccount = MSS.Domain.Concrete.DatabaseEntities.UserAccount.UserAccount;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory
{
    public interface IUserAccountFactory
    {
        DomainUserAccount Create(
            string email,
            string firstName = null, 
            string lastName = null, 
            string affix = null,
            string userName = null);
    }
}