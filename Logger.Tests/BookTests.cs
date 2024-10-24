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
        FullName author = new("Inigo", "Montoya", "Ella");
        string isbn = "1234567890";
        Book book = new("Test", author, isbn);
        // Act
        var result = book;
        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Record_Instantiation_HasId()
    {
        // Arrange
        FullName author = new("Inigo", "Montoya", "Ella");
        string isbn = "1234567890";
        var book = new Book("Test", author, isbn);

        // Act 
        var bookEntity = (IEntity)book;
        Guid bookGuid = bookEntity.Id; 

        // Assert
        Assert.NotEqual(Guid.Empty, bookGuid);
    }

    [Fact]
    public void Record_GivenInput_ReturnsExpectedName()
    {
        // Arrange
        FullName author = new("Inigo", "Montoya", "Ella");
        string isbn = "1234567890";
        var book = new Book("Test", author, isbn);
        // Act
        var result = book.Name;
        // Assert
        Assert.Equal("Test by Inigo Ella Montoya", result);
    }

    [Fact]
    public void Book_ShouldThrowArgumentException_WhenTitleIsNullOrEmpty()
    {
        // Arrange
        var author = new FullName("Inigo", "Montoya", "Ella");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => new Book(string.Empty, author, "123456789"));
        Assert.Equal("Title cannot be null or empty. (Parameter 'title')", exception.Message);

        exception = Assert.Throws<ArgumentException>(() => new Book(string.Empty, author, "123456789"));
        Assert.Equal("Title cannot be null or empty. (Parameter 'title')", exception.Message);
    }
}
