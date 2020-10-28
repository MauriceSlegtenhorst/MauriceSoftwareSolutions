using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult
{
    /// <remark>Must never contain sensitive information</remark>
    public class CommandResult : IResult
    {
        public bool IsSucceded { get; set; }
        public string[] Messages { get; set; }
    }
}
