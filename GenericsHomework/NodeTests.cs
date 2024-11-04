using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework;

[TestClass]
public class NodeTests
{

    [TestMethod]
    public void ToString_NullNode_ReturnsNull()
    {
        Console.WriteLine("Is working");
        Node<string> newNode = null;
        Assert.ThrowsException<NullReferenceException>(() => newNode?.ToString());
    }


    // IEnumerable for testing different kinds of objects.  Used by test below
    public static IEnumerable<object> AdditionData
    {
        get
        {
            return new object[]
            {
                "",
                "Hello World",
                new Node<string>("DATA"),
                new DateTime(year: 1603, month: 10, day: 12)
            };
        }
    }


    [TestMethod]
    [DynamicData(nameof(AdditionData))]
    public void ToString_TestingVariousObjects_Passes(object value)
    {
        // Arrange
        Type type = value.GetType().BaseType;
        Node<object> newNode = new(value);
        
        // Assert
        Assert.AreEqual(value, newNode.ToString());
    }


    // Test Append

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
