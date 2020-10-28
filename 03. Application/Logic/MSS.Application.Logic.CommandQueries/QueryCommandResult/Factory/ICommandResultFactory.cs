using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public interface ICommandResultFactory
    {
        CommandResult Create(bool isSucceded, string[] messages = null);
    }
}