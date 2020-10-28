using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult
{
    public interface IResult
    {
        bool IsSucceded { get; set; }

        string[] Messages { get; set; }
    }
}
