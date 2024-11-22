using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class SampleDataBaseTests
{
    [TestMethod]
    public void Constructor_ValidFileName_ShouldNotThrowException()
    {
        // Arrange
        string fileName = "People.csv";

        // Act
        SampleDataBase sampleDataBase = new SampleDataAsync(fileName);

        // Assert
        Assert.IsNotNull(sampleDataBase);
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void Constructor_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
    {
        // Arrange
        // Act
        _ = new SampleDataAsync("NonExistentFile.csv");
        // Assert - Expecting a FileNotFoundException
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Constructor_InvalidHeader_ShouldThrowInvalidFormatException()
    {
        // Arrange
        string fileName = "TestFile.csv";
        File.WriteAllText(fileName, "FirstName");
        try
        {
            SampleDataAsync sampleData = new(fileName);
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Constructor_ShouldThrowFormatException_WhenHeaderDoesNotMatchExpected()
    {
        // Arrange
        string fileName = "TestFile.csv";
        File.WriteAllText(fileName, "Id,FirstName,LastName,Email,Street,City,State,PostalCode");
        try
        {
            SampleDataAsync sampleData = new(fileName);
        }
        finally
        {
            File.Delete(fileName);
        }
    }
}