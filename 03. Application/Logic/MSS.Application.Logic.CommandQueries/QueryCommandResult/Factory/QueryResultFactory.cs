using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public sealed class QueryResultFactory : IQueryResultFactory
    {
        public QueryResult<TResult> Create<TResult>(bool isSucceded, TResult resultItem, string[] messages = null, Exception exception = null)
        {
            return new QueryResult<TResult>
            {
                IsSucceded = isSucceded,
                Messages = messages,
                Exception = exception,
                Result = resultItem
            };
        }
    }
}
