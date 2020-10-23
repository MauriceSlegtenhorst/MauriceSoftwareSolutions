using System;
using System.Collections.Generic;
using System.Text;

namespace MSS.CrossCuttingConcerns.Infrastructure.ConstantData
{
    [Flags]
    public enum Roles : byte
    {
        StandardUser = 1,
        PrivilegedUser = 2,
        Volenteer = 4,
        Employee = 8,
        PrivilegedEmployee = 16,
        Administrator = 32
    }
}
