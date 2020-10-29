﻿using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public sealed class CommandResultFactory : ICommandResultFactory
    {
        public CommandResult Create(bool isSucceded, string[] messages = null)
        {
            return new CommandResult
            {
                IsSucceeded = isSucceded,
                Messages = messages
            };
        }
    }
}
