﻿using Microsoft.AspNetCore.Identity;
using System;

namespace MSS.Domain.Concrete.DatabaseEntities.Identity
{
    /// <Summary>Represents an authentication token for a user. Only valid for set time</Summary>
    /// <Exception cref="ArgumentException">Thrown if one of the parameters is invalid</Exception>
    public sealed class SessionAuthenticationToken : IdentityUserToken<string>
    {
        public SessionAuthenticationToken(
            string userId,
            string loginProvider,
            string userName,
            string jwtSecurityToken)
        {
            if (String.IsNullOrEmpty(userId))
                throw new ArgumentException($"Parameter {nameof(userId)} cannot be null or empty");
            UserId = userId;

            if (String.IsNullOrEmpty(loginProvider))
                throw new ArgumentException($"Parameter {nameof(loginProvider)} cannot be null or empty");
            LoginProvider = loginProvider;

            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException($"Parameter {nameof(userName)} cannot be null or empty");
            Name = userName;

            if (String.IsNullOrEmpty(jwtSecurityToken))
                throw new ArgumentException($"Parameter {nameof(jwtSecurityToken)} cannot be null or empty");
            Value = jwtSecurityToken;
        }
    }
}
