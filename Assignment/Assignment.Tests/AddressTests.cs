using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class AddressTests
{
    [TestMethod]
    public void Constructor_ValidInputs_Initializes()
    {
        // Arrange
        string streetAddress = "123 Main St";
        string city = "Anytown";
        string state = "Anystate";
        string zip = "12345";

        // Act
        Address address = new(streetAddress, city, state, zip);

        // Assert
        Assert.AreEqual(streetAddress, address.StreetAddress);
        Assert.AreEqual(city, address.City);
        Assert.AreEqual(state, address.State);
        Assert.AreEqual(zip, address.Zip);
    }

    [DataTestMethod]
    [DataRow(null, "Anytown", "Anystate", "12345")]
    [DataRow("123 Main St", null, "Anystate", "12345")]
    [DataRow("123 Main St", "Anytown", null, "12345")]
    [DataRow("123 Main St", "Anytown", "Anystate", null)]
    public void Constructor_NullInputs_ThrowsException(string streetAddress, string city, string state, string zip)
    {
        // Arrange

        // Act

        // Assert
        Assert.ThrowsException<ArgumentException>(() => new Address(streetAddress, city, state, zip));
    }

    [DataTestMethod]
    [DataRow("  ", "Anytown", "Anystate", "12345")]
    [DataRow("123 Main St", "", "Anystate", "12345")]
    [DataRow("123 Main St", "Anytown", "", "12345")]
    [DataRow("123 Main St", "Anytown", "Anystate", "")]
    public void Constructor_EmptyInputs_ThrowsException(string streetAddress, string city, string state, string zip)
    {
        // Arrange

        // Act

        // Assert
        Assert.ThrowsException<ArgumentException>(() => new Address(streetAddress, city, state, zip));
    }
}