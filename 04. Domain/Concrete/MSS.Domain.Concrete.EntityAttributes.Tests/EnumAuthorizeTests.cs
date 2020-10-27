using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using System;
using Xunit;

namespace MSS.Domain.Concrete.EntityAttributes.Tests
{
    public class EnumAuthorizeTests
    {
        [Fact]
        public void EnumAuthorize_ConvertsEnumToString()
        {
            // Arrange
            var expected = "Administrator";
            var roles = Roles.Administrator;

            // Act
            var actual = roles.ToString().Replace(" ", String.Empty);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EnumAuthorize_ConvertsEnumToCommaSeparatedString()
        {
            // Arrange
            var expected = "Employee,PrivilegedEmployee,Administrator";
            var roles = Roles.Administrator | Roles.Employee | Roles.PrivilegedEmployee;

            // Act
            var actual = roles.ToString().Replace(" ", String.Empty);

            Assert.Equal(expected, actual);
        }
    }
}
