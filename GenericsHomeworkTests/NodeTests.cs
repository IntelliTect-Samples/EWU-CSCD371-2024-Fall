using GenericsHomework;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{

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
    // null node
    // list with 1 node
    // list with a few nodes

    // Test Exists
    // null node
    // list with 1 node
    // list with a few nodes

    // Test Value/Next properties?
}
