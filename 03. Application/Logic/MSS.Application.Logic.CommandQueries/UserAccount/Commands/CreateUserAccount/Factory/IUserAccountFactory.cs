
namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount.Factory
{
    public interface IUserAccountFactory
    {
        Domain.Concrete.DatabaseEntities.UserAccount.UserAccount Create(
            string email,
            string firstName = null, 
            string lastName = null, 
            string affix = null,
            string userName = null);
    }
}