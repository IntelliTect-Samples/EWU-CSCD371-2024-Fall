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
    public void Person_Constructed_exists()
    {
        // Arrange
        string name = "John Doe";

        // Act
        TestPerson person = new(name);

        // Assert
        Assert.NotNull(person);
    }

}

public class TestPerson(string name) : Person
{
    public override string Name { get; } = name;
}