using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    [Fact]
    public void StudentCreation_NotNull_ReturnsNotNull()
    {
        //Act
        Student student = new();

        //Assert
        Assert.NotNull(student);
    }
}
