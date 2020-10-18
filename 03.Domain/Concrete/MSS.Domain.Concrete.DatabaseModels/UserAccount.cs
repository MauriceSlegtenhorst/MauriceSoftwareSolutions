using Microsoft.AspNetCore.Identity;
using MSS.Domain.Common.Interfaces;
using System;

namespace MSS.Domain.Concrete.DatabaseModels
{
    public sealed class UserAccount : IdentityUser, IEntity
    {
        public DateTime CreationDateUTC { get; set; }
        public DateTime? ModificationDateUTC { get; set; }
        public string FirstName { get; set; }
        public string Affix { get; set; }
        public string LastName { get; set; }
        public bool IsAdmitted { get; set; }
    }
}
