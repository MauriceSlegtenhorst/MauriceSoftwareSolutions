using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public sealed class QueryResultFactory : IQueryResultFactory
    {
        public QueryResult Create(bool isSucceded, Type resultItemType, object resultItem, string[] messages = null, Exception exception = null)
        {
            return new QueryResult
            {
                IsSucceded = isSucceded,
                Messages = messages,
                Exception = exception,
                ResultItemType = resultItemType,
                ResultItem = resultItem
            };
        }
    }
}
