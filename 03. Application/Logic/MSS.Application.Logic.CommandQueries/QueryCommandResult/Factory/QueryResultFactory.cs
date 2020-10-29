using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public class QueryResultFactory : IQueryResultFactory
    {
        public QueryResult<TResult> Create<TResult>(bool isSucceded, TResult resultItem, string[] messages = null)
        {
            return new QueryResult<TResult>
            {
                IsSucceeded = isSucceded,
                Messages = messages,
                Result = resultItem
            };
        }
    }
}
