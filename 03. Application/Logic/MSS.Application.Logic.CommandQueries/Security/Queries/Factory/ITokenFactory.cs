using MSS.Domain.Concrete.DatabaseEntities.Identity;
using System.Threading.Tasks;
using System;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.Factory
{
    public interface ITokenFactory
    {
        /// <exception cref="ArgumentException">Thrown when the string parameter userName is invalid</exception>
        /// <exception cref="NullReferenceException">Thrown when the no user was found with the provided username string</exception>
        Task<SessionAuthenticationToken> Create(string userName, bool isPersistent);
    }
}