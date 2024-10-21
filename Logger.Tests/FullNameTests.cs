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
    public void RecordCreation_WithFullName_Success()
    {
        // Arrange

        // Act
        FullName fullName = new();

        // Assert
        Assert.NotNull(fullName);
        Assert.IsType<FullName>(fullName);
    }
}
