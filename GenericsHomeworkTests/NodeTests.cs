using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    // ToString Tests
    #region ToStringTests

    [TestMethod]
    public void ToString_NullNode_ReturnsNull()
    {
        Node<string>? newNode = null;
        Assert.ThrowsException<NullReferenceException>(() => newNode!.ToString());
    }


    // IEnumerable for testing different kinds of objects.  Used by test below
    static IEnumerable<object[]> AdditionData
    {
        get
        {
            return new[]
            {
                new object[] {"Test"},
                new object[] {"HelloWorld"},
                new object[] { new Node<string>("DATA") },
                new object[] { new DateTime(year: 1603, month: 10, day: 12) }
            };
        }
    }

    [TestMethod]
    [DynamicData(nameof(AdditionData))]
    public void ToString_TestingVariousObjects_Passes(object value)
    {

        // Arrange
        Node<object> newNode = new(value);

        // Assert
        Assert.AreEqual(value.ToString(), newNode.ToString());
    }

    #endregion

    // Test Append
    #region AppendTests

    [TestMethod]
    public void Append_AddsNewNode_Passes()
    {
        // Arrange
        Node<object> newNode = new("First");
        // Act
        newNode.Append("Second");
        // Assert
        Assert.AreEqual("Second", newNode.Next.ToString());
    }

    [TestMethod]
    public void Append_AppendToEnd_Passes()
    {
        // Arrange
        Node<object> newNode = new("First");
        newNode.Append("Second");
        Node<object> secondNode = newNode.Next;

        // Act
        secondNode.Append("Third");

        // Assert
        Assert.AreEqual("Third", secondNode.Next.ToString());
    }

    [TestMethod]
    public void Append_AppendToFrontOfFirstNode_Passes()
    {
        // Arrange
        Node<object> newNode = new("First");

        // Act
        newNode.Append("Second to front");
        newNode.Append("Third to front");
        newNode.Append("Fourth to front");

        // Assert
        Assert.AreEqual("Fourth to front", newNode.Next.ToString());
    }

    #endregion

    // Test Clear
    #region ClearTests

    [TestMethod]
    public void Clear_ClearsNonEmptyList_Passes()
    {
        // Arrange
        Node<object> newNode = new("A");
        Node<object> expectedNode = newNode.Next;

        // Act
        newNode.Append('B');
        newNode.Next.Append('C');
        newNode.Clear();

        // Assert
        Assert.AreEqual(expectedNode, newNode);
    }

    [TestMethod]
    public void Clear_MultipleClearsInARow_Passes()
    {
        // Arrange
        Node<object> newNode = new("A");
        Node<object> expectedNode = newNode.Next;

        // Act
        newNode.Clear();
        newNode.Clear();
        newNode.Clear();

        // Assert
        Assert.AreEqual(expectedNode, newNode);
    }

    #endregion

    // Test Exists
    #region ExistsTests

    [TestMethod]
    public void Exists_TryFindingExistingData_Passes()
    {
        // Arrange
        Node<object> newNode = new("");
        // Assert
        Assert.IsTrue(newNode.Exists(""));
    }

    [TestMethod]
    public void Exists_TryFindingNonExistentData_Passes()
    {
        // Arrange
        Node<object> newNode = new("Try This!");
        // Assert
        Assert.IsFalse(newNode.Exists("Other string"));
    }

    [TestMethod]
    public void Exists_TryFindingDataWithManyNodes_Passes()
    {
        // Arrange
        Node<object> newNode = new("H");
        // Act
        newNode.Append("D");
        newNode.Append("L");
        newNode.Append("R");
        newNode.Append("O");
        newNode.Append("W");
        newNode.Append("ello");

        // Assert
        Assert.IsTrue(newNode.Exists("D"));
        Assert.IsFalse(newNode.Exists("Not in it"));
    }

    #endregion

}
