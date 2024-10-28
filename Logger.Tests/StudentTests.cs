using System;
using Xunit;

namespace Logger.Tests;
public class StudentTests
{

    [Fact]
    public void Student_AllInputs_CreateStudent()
    {
        // Arrange
        Student newStudent = new("01", "John", "Middle", "Doe");

        // Act & Assess
        Assert.IsAssignableFrom<IEntity>(entity);
    }
}
