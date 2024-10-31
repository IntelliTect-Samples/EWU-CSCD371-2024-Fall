using Xunit;

namespace Logger.Tests
{
    public class BookTests
    {
        [Fact]
        public void CreateBook_ValidParameters_ReturnsBookObject()
        {
            // Arrange
            var title = "Sample Book";
            var author = new FullName
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith"
            };
            var year = 2022;
            var isbn = "1234567890";

            // Act
            var book = new Book(title, author, year, isbn);

            // Assert
            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
            Assert.Equal(year, book.Year);
            Assert.Equal(isbn, book.ISBN);
        }

        [Fact]
        public void ParseName_ValidBook_ReturnsFormattedName()
        {
            // Arrange
            var title = "Sample Book";
            var author = new FullName
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith"
            };
            var year = 2022;
            var isbn = "1234567890";
            var book = new Book(title, author, year, isbn);

            // Act
            var parsedName = book.ParseName();

            // Assert
            Assert.Equal($"{title} by {author}, Year: {year}, ISBN: {isbn}", parsedName);
        }
    }
}