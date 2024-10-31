using Xunit;

namespace Logger.Tests;

    public class BookTests
    {
        [Fact]
        public void CreateBookValidParametersReturnsBookObject()
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
        public void ParseNameValidBookReturnsFormattedName()
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
        [Fact]
        public void CreateBookNullParametersThrowsArgumentNullException()
        {
            // Arrange
            string title = null!;
            FullName author = null!;
            int year = 2;
            string isbn = null!;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Book(title, author, year, isbn));
        }
    }
