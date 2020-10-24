using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult
{
    public class QueryResult : IResult
    {
        public bool IsSucceded { get; set; }
        public string[] Messages { get; set; }
        public Exception Exception { get; set; }
        public Type ResultItemType { get; set; }
        public object ResultItem { get; set; }
    }
}
