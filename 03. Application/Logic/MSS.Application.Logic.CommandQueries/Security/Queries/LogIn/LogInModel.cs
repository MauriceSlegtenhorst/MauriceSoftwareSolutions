using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Application.Logic.CommandQueries.Security.Queries.LogIn
{
    public sealed class LogInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
