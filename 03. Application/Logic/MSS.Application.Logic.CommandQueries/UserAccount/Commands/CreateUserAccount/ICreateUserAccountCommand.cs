using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using System.Threading;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Commands.CreateUserAccount
{
    public interface ICreateUserAccountCommand
    {
        Task<CommandResult> Execute(CreateUserAccountModel model, CancellationToken cancellationToken);
    }
}