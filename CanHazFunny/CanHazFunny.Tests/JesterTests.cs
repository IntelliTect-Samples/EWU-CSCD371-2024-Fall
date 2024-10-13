using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;


public class JesterTests
{
    [Fact]
    public void ClassCreation_CreateNewInstance_Success()
    {
        // Arrange
        Jester jester = new();

        // Act

        // Assert
        Assert.NotNull(jester);
    }
}
