using Microsoft.AspNetCore.Identity;
using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.Persistence.ObjectRelationalMapping.Seed
{
    internal sealed class IdentityRoleSeedData
    {
        private IdentityRoleSeedData() { }

        internal static IdentityRole[] Build()
        {
            var roles = Enum.GetNames(typeof(Roles));
            var identityRoles = new IdentityRole[roles.Length];

            for (int i = 0; i < roles.Length; i++)
            {
                identityRoles[i] = new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roles[i],
                    NormalizedName = roles[i].ToUpper()
                };
            }

            return identityRoles;
        }
    }
}
