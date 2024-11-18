using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class PersonTests
{
    [DataTestMethod]
    [DataRow("John", "Doe", "john.doe@example.com")]
    public void Constructor_ValidInputs_Initializes(string firstName, string lastName, string emailAddress)
    {
        // Arrange
        Address address = new("123 Main St", "Anytown", "Anystate", "12345");
        Person person = new(firstName, lastName, address, emailAddress);

        // Act

        // Assert
        Assert.AreEqual(firstName, person.FirstName);
        Assert.AreEqual(lastName, person.LastName);
        Assert.AreEqual(address, person.Address);
        Assert.AreEqual(emailAddress, person.EmailAddress);
    }

    [DataTestMethod]
    [DataRow(null, "Doe", "john.doe@example.com")]
    [DataRow("John", null, "john.doe@example.com")]
    [DataRow("John", "Doe", null)]
    public void Constructor_NullInputs_ThrowsException(string firstName, string lastName, string emailAddress)
    {
        // Arrange
        Address address = new("123 Main St", "Anytown", "Anystate", "12345");

        // Act

        // Assert
        Assert.ThrowsException<ArgumentException>(() => new Person(firstName, lastName, address, emailAddress));
    }

    [DataTestMethod]
    [DataRow("", "Doe", "john.doe@example.com")]
    [DataRow("John", "  ", "john.doe@example.com")]
    [DataRow("John", "Doe", "")]
    public void Constructor_EmptyInputs_ThrowsException(string firstName, string lastName, string emailAddress)
    {
        // Arrange
        Address address = new("123 Main St", "Anytown", "Anystate", "12345");

        // Act

        // Assert
        Assert.ThrowsException<ArgumentException>(() => new Person(firstName, lastName, address, emailAddress));
    }

    [TestMethod]
    public void Constructor_NullAddress_ThrowsException()
    {
        // Arrange

        // Act

        // Assert
        Assert.ThrowsException<ArgumentNullException>(() => new Person("John", "Doe", null!, "john.doe@example.com"));
    }
}