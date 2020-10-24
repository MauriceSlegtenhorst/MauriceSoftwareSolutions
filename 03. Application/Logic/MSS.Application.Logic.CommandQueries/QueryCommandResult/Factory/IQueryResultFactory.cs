using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public interface IQueryResultFactory
    {
        QueryResult<TResult> Create<TResult>(bool isSucceded, TResult resultItem, string[] messages = null, Exception exception = null);
    }
}