using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class FullNameTests
{
    [Fact]
    public void RecordCreation_NoParameters_Success()
    {
        // Arrange

        // Act
        FullName fullName = new("testFirst", "testMiddle", "testLast");

        // Assert
        Assert.NotNull(fullName);
        Assert.IsType<FullName>(fullName);
    }

    [Fact]
    public void RecordCreation_WithFullName_Success()
    {
        // Arrange
        string firstName = "Inigo";
        string middleName = "Ella";
        string lastName = "Montoya";

        // Act
        FullName fullName = new(firstName, lastName, middleName);

        // Assert
        Assert.NotNull(fullName);
        Assert.IsType<FullName>(fullName);
        Assert.Equal(firstName, fullName.FirstName);
        Assert.Equal(middleName, fullName.MiddleName);
        Assert.Equal(lastName, fullName.LastName);
    }

    [Fact]
    public void RecordCreation_NameWithOutMiddleName_Success()
    {
        // Arrange
        string firstName = "Inigo";
        string lastName = "Montoya";

        // Act
        FullName fullName = new(firstName, lastName);

        // Assert
        Assert.Equal(firstName, fullName.FirstName);
        Assert.Equal(lastName, fullName.LastName);
        Assert.Equal(string.Empty, fullName.MiddleName);
    }

    [Theory]
    [InlineData(null, "Montoya", "Elly")]
    [InlineData("Inigo", null, "Elly")]
    [InlineData("Inigo", "Montoya", null)]
    public void RecordCreation_CheckNullThrowsException__ThrowsException(string firstName, string lastName, string middleName)
    {
        if (firstName == null)
        {
            Assert.Throws<ArgumentException>(() => new FullName(firstName!, lastName, middleName));
        }
        else if (lastName == null)
        {
            Assert.Throws<ArgumentException>(() => new FullName(firstName, lastName!, middleName));
        }
        else if (middleName == null)
        {
            Assert.Throws<ArgumentException>(() => new FullName(firstName, lastName, middleName!));
        }
    }
}
