using MSS.Application.Logic.CommandQueries.QueryCommandResult;
using System;
using System.Threading.Tasks;

namespace MSS.Application.Logic.CommandQueries.Security.Commands.LogOut
{
    public interface ILogOutCommand
    {
        Task<Tuple<int, CommandResult>> Execute();
    }
}