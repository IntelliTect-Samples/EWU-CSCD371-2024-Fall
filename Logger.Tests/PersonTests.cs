using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class PersonTests
{

    [Fact]
    public void Initialization_Constructed_exists()
    {
        // Arrange
        FullName fullName = new("Inigo", "Montoya", "Ella");

        // Act
        TestPerson person = new(fullName);

        // Assert
        Assert.NotNull(person);
    }

    [Fact]
    public void Initialization_GivenINput_ReturnsExpectedName()
    {
        // Arrange
        FullName fullName = new("Inigo", "Montoya", "Ella");
        String expected = "Inigo Ella Montoya";
        //Act
        TestPerson person = new(fullName);

        //Assert
        Assert.Equal(expected, person.Name);
    }
}

public record class TestPerson(FullName NameDetails) : Person(NameDetails)
{

}
