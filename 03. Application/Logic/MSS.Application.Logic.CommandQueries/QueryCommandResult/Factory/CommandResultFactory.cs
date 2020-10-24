using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public sealed class CommandResultFactory : ICommandResultFactory
    {
        public CommandResult Create(bool isSucceded, string[] messages = null, Exception exception = null)
        {
            return new CommandResult
            {
                IsSucceded = isSucceded,
                Messages = messages,
                Exception = exception
            };
        }
    }
}
