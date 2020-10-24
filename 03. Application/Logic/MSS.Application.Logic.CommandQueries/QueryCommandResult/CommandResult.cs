using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult
{
    public class CommandResult : IResult
    {
        public bool IsSucceded { get; set; }
        public string[] Messages { get; set; }
        public Exception Exception { get; set; }
    }
}
