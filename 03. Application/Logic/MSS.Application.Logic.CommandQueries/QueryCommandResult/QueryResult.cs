using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult
{
    public class QueryResult<TResult> : IResult
    {
        public bool IsSucceded { get; set; }
        public string[] Messages { get; set; }
        public Exception Exception { get; set; }
        public TResult Result { get; set; }
    }
}
