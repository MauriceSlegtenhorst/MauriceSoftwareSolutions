using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult
{
    public interface IResult
    {
        bool IsSucceeded { get; set; }

        string[] Messages { get; set; }
    }
}
