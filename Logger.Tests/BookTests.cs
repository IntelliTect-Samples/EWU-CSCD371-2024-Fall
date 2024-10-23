using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Fact]
    public void Record_Constructed_Exists()
    {
        // Arrange
        var book = new Book("Test");
        // Act
        var result = book;
        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Record_Instantiation_HasId()
    {
        // Arrange
        var book = new Book("Test");
        // Act
        var result = book.Id;
        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public void Record_GivenInput_ReturnsExpectedName()
    {
        // Arrange
        var book = new Book("Test");
        // Act
        var result = book.Name;
        // Assert
        Assert.Equal("Test", result);
    }
}
