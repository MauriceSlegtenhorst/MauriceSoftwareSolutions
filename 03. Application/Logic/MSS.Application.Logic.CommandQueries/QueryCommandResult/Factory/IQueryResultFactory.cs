using System;

namespace MSS.Application.Logic.CommandQueries.QueryCommandResult.Factory
{
    public interface IQueryResultFactory
    {
        QueryResult Create(bool isSucceded, Type resultItemType, object resultItem, string[] messages = null, Exception exception = null);
    }
}