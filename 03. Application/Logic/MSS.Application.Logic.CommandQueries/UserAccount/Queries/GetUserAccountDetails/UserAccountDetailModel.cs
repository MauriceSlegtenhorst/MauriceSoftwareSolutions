using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Application.Logic.CommandQueries.UserAccount.Queries.GetUserAccountDetails
{
    public sealed class UserAccountDetailModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Affix { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
