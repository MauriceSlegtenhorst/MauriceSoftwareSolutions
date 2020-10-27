using Microsoft.AspNetCore.Authorization;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using System;

namespace MSS.Domain.Concrete.EntityAttributes
{
    public class EnumAuthorizeAttribute : AuthorizeAttribute
    {
        public EnumAuthorizeAttribute(Roles roles) 
        {
            Roles = roles.ToString().Replace(" ", String.Empty);
        }
    }
}
