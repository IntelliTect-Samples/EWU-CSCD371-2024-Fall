using Xunit;

namespace Logger.Tests
{
    public class BookTests
    {
        [Fact]
        public void CreateBook_SetTitleAndAuthor_Success()
        {
            // Arrange & Act
            var book = new Book("A Painted House", "John Grisham");

            // Assert
            Assert.Equal("A Painted House", book.Title);
            Assert.Equal("John Grisham", book.Author);
        }

        [Fact]
        public void Book_NameProperty_ShouldReturnTitle()
        {
            // Arrange
            var book = new Book("To Kill a Mockingbird", "Harper Lee");

            // Act
            var bookName = book.Name;

            // Assert
            Assert.Equal("To Kill a Mockingbird", bookName);
        }

        [Fact]
        public void Book_UniqueId_Success()
        {
            // Arrange
            var book1 = new Book("A Painted House", "John Grisham");
            var book2 = new Book("Into The Wind", "Neil Gaiman");

            // Act & Assert
            Assert.NotEqual(book1.Id, book2.Id);
        }

        [Fact]
        public void CreateBook_WithoutTitle_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Book(null!, "John Grisham"));
        }

        [Fact]
        public void CreateBook_WithoutAuthor_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Book("A Painted House", null!));
        }
    }
}

