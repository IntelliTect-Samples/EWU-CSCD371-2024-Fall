using MathExtensions;

namespace MathTest;

[TestClass]
public sealed class ThingTests
{
    [TestMethod]
    public void Name_InigoMontoya_Success()
    {
        // Arrange
        string name = "Inigo Montoya";
        // Act
        Thing thing = new();
        thing.Name = name;
        // Assert
        Assert.AreEqual(name, thing.Name);
    }

    [TestMethod]
    public void Age_42_Success()
    {
        // Arrange
        float age = 42;
        // Act
        Thing thing = new();
        thing.Age = age;
        // Assert
        Assert.AreEqual(age, thing.Age);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Age_SetNegativeNumber_ThrowsException()
    {
        // Arrange
        Thing thing = new();
        // Act
        thing.Age = -1;
        // Assert
        // Assert is managed by the Attribute [ExpectedException]
    }

    [TestMethod]
    public void FirstName_Inigo_Success()
    {
        // Arrange
        string firstName = "Inigo";
        // Act
        Thing thing = new();
        thing.FirstName = firstName;
        // Assert
        Assert.AreEqual(firstName, thing.FirstName);
    }

    [TestMethod]
    public void Name_Set_AssignsFirstName()
    {
        // Arrange
        string name = "Inigo Montoya";
        Thing thing = new();
        // Act
        thing.Name = name;
        // Assert
        Assert.AreEqual("Inigo", thing.FirstName);
    }


}
