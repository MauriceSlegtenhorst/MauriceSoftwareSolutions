using MSS.CrossCuttingConcerns.Infrastructure.ConstantData;
using System;
using Xunit;

namespace MSS.Domain.Concrete.EntityAttributes.Tests
{
    public class EnumAuthorizeTests
    {
        [Fact]
        public void ConvertsEnumToString()
        {
            // Arrange
            var expected = "Administrator";
            var roles = Roles.Administrator;

            // Act
            var actual = roles.ToString().Replace(" ", String.Empty);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertsEnumToCommaSeparatedString()
        {
            // Arrange
            var expected = "Employee,PrivilegedEmployee,Administrator";
            var roles = Roles.Administrator | Roles.Employee | Roles.PrivilegedEmployee;

            // Act
            var actual = roles.ToString().Replace(" ", String.Empty);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EnumAuthorize_ConvertsFlagsEnumToString()
        {
            // Arrange
            var roles = Roles.Administrator | Roles.Employee | Roles.PrivilegedEmployee;
            var expected = "Employee,PrivilegedEmployee,Administrator";
            var enumAuthorizeAttribute = new EnumAuthorizeAttribute(roles);

            // Act
            var actual = enumAuthorizeAttribute.Roles;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
