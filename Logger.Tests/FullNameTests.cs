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
    public void RecordCreation_CheckNullThrowsException__ThrowsException(string? firstName, string? lastName,
        string? middleName)
    {

        Assert.Throws<ArgumentException>(() => new FullName(firstName!, lastName!, middleName!));

    }

    [Fact]
    public void RecordCreation_CheckNullMiddleNameThrowsException__ThrowsException()
    {
        // Arrange
        string firstName = "Inigo";
        string lastName = "Montoya";

        // Act
        Assert.Throws<ArgumentNullException>(() => new FullName(firstName, lastName, null!));
    }

    [Theory]
    [InlineData("Inigo", "Montoya", "Elly")]
    public void ToString_ThreeNames_ReturnsExpected(string firstName, string lastName, string middleName)
    {
        // Arrange
        FullName fullName = new(firstName, lastName, middleName);
        string expected = $"{firstName} {middleName} {lastName}";
        // Act
        string actual = fullName.ToString();
        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Inigo", "Montoya")]
    public void ToString_TwoNames_ReturnsExpected(string firstName, string lastName)
    {
        // Arrange
        FullName fullName = new(firstName, lastName);
        string expected = $"{firstName} {lastName}";
        // Act
        string actual = fullName.ToString();
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SetName_ChangeName_ReturnsExpected()
    {
        // Arrange
        FullName fullName = new("Inigo", "Montoya", "Elly");
        string oldName = "Inigo Elly Montoya";

        // Act
        fullName.FirstName = "James";
        fullName.MiddleName = "Edward";
        fullName.LastName = "McNugget";

        // Assert
        Assert.NotEqual(oldName, fullName.ToString());
        Assert.Equal("James Edward McNugget", fullName.ToString());
    }

}

