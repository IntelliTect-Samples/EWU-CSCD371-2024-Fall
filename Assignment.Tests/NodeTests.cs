using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

//We understand that logic in tests is typically frowned upon, but the assignment recommends we don't use collection assertions,
//Thus we must iterate :)

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void GetEnumerator()
    {
        //Arrange
        Node<string> node = new("val1");
        node.Append("Why");
        node.Append("hello");
        node.Append("there");

        //Act
        IEnumerator<string> enumerator = node.GetEnumerator();

        //Assert
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("val1", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("Why", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("hello", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("there", enumerator.Current);
        Assert.IsFalse(enumerator.MoveNext());
    }

    [TestMethod]
    public void ChildItems_ValidNodes_ReturnsValues()
    {
        //Arrange
        Node<string> node = new("val1");
        node.Append("Why");
        node.Append("hello");
        node.Append("there");

        //Act
        IEnumerable<string> enumerable = node.ChildItems(2);
        List<string> resultList = enumerable.ToList();

        //Assert
        Assert.AreEqual(2, enumerable.Count());
        Assert.AreEqual("val1", resultList[0]);
        Assert.AreEqual("Why", resultList[1]);
    }


    [DataTestMethod]
    [DataRow(13)]
    [DataRow(13.0)]
    [DataRow("Hello!")]
    public void Constructor_VariousDataTypes_ContainsExpectedDataTypes<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        Type expectedType = typeof(T);
        Type actualType = node.Value!.GetType();

        // Assert
        Assert.AreEqual(expectedType, actualType);
    }

    [TestMethod]
    public void Next_NodeOnCreation_NextReferencesItself()
    {
        // Arrange
        int value = 13;

        // Act
        Node<int> node = new(value);

        // Assert
        Assert.AreSame(node, node.Next);
    }

    [DataTestMethod]
    [DataRow("Data!")]
    [DataRow("")]
    [DataRow(42)]
    [DataRow(new[] { 32 })]
    public void ToString_GivenData_ReturnsExpectedValue<T>(T value)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        string nodeOut = node.ToString();

        // Assert
        Assert.AreEqual($"{node.Value}", nodeOut);
    }

    [TestMethod]
    public void ToString_Null_ReturnsExpectedValue()
    {
        // Arrange
        Node<object?> node = new(null);
        string expectedOut = "Value does not exist.";

        // Act
        string nodeOut = node.ToString();

        // Assert
        Assert.AreEqual(expectedOut, nodeOut);
    }

    [TestMethod]
    public void Append_GivenData_NextPointsAsExpected()
    {
        // Arrange
        Node<int> node = new(13);

        // Act
        node.Append(42);

        // Assert
        Assert.AreEqual(node, node.Next.Next);
        Assert.AreEqual(node.Next, node.Next.Next.Next);
        Assert.AreNotEqual(node.Next, node);
    }

    [DataTestMethod]
    [DataRow(13, 42)]
    [DataRow(13.0, 12.0)]
    [DataRow("Hello!", "Goodbye")]
    public void Append_GivenData_AppendsData<T>(T value, T value2)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);

        // Assert
        Assert.AreEqual(value, node.Value);
        Assert.AreEqual(value2, node.Next.Value);
        Assert.AreEqual(value, node.Next.Next.Value);
        Assert.AreEqual(value2, node.Next.Next.Next.Value);
        Assert.AreNotEqual(value, node.Next.Value);
        Assert.AreNotEqual(value2, node.Next.Next.Value);
    }

    [DataTestMethod]
    [DataRow(42, 42)]
    [DataRow(42.0, 42.0)]
    [DataRow("42", "42")]
    public void Append_DuplicateValues_ThrowsException<T>(T value1, T value2)
    {
        // Arrange
        Node<T> node = new(value1);

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => node.Append(value2));
    }

    [DataTestMethod]
    [DataRow(42, 43, 42)]
    [DataRow(42.0, 43.0, 42.0)]
    [DataRow("fortytwo", "fortythree", "fortytwo")]
    public void Append_DuplicateValues_MessageBeingDisplayedIsCorrect<T>(T value, T value2, T value3)
    {
        // Arrange
        Node<T> node = new(value);
        node.Append(value2);
        string expectedMessage = "Value already exists in this list.";

        // Act & Assert
        InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() => node.Append(value3));
        Assert.AreEqual(expectedMessage, ex.Message);
    }

    [DataTestMethod]
    [DataRow(13, 42, 18)]
    [DataRow(13.0, 12.0, 14.0)]
    [DataRow("Hello!", "Goodbye", "Auf wiedersehen")]
    public void Append_MoreGivenData_AppendsData<T>(T value, T value2, T value3)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);
        node.Append(value3);

        // Assert
        Assert.AreEqual(value, node.Value);
        Assert.AreEqual(value2, node.Next.Value);
        Assert.AreEqual(value3, node.Next.Next.Value);
        Assert.AreEqual(value, node.Next.Next.Next.Value);
        Assert.AreEqual(value2, node.Next.Next.Next.Next.Value);
        Assert.AreEqual(value3, node.Next.Next.Next.Next.Next.Value);
        Assert.AreNotEqual(value, node.Next.Value);
        Assert.AreNotEqual(value2, node.Next.Next.Value);
        Assert.AreNotEqual(value3, node.Next.Next.Next.Value);
    }

    [TestMethod]
    public void AppendAndClear_Data_NodesShouldPointToThemselves()
    {
        // Arrange
        Node<int> node = new(42);
        node.Append(14);
        node.Append(32);

        Node<int> secondNode = node.Next;
        Node<int> thirdNode = node.Next.Next;

        // Act
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
        Assert.AreEqual(42, node.Value);
        Assert.AreEqual(secondNode, secondNode.Next);
        Assert.AreEqual(14, secondNode.Value);
        Assert.AreEqual(thirdNode, thirdNode.Next);
        Assert.AreEqual(32, thirdNode.Value);
    }

    [DataTestMethod]
    [DataRow(42, 43, 48)]
    [DataRow(42.0, 43.0, 44.0)]
    [DataRow("fortytwo", "fortythree", "fortyfour")]
    public void Clear_GivenMoreData_ClearsItemsExceptCurrentNode<T>(T value, T value2, T value3)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);
        node.Append(value3);
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
        Assert.AreEqual(value, node.Value);
    }

    [DataTestMethod]
    [DataRow(42, 43, 48, 49)]
    [DataRow(42.0, 43.0, 44.0, 45.0)]
    [DataRow("fortytwo", "fortythree", "fortyfour", "fortyfive")]
    public void Exists_NodeList_ContainsValue<T>(T value, T value2, T value3, T value4)
    {
        // Arrange
        Node<T> node = new(value);

        // Act
        node.Append(value2);
        node.Append(value3);
        node.Append(value4);

        // Assert
        Assert.IsTrue(node.Exists(value));
        Assert.IsTrue(node.Exists(value2));
        Assert.IsTrue(node.Exists(value3));
        Assert.IsTrue(node.Exists(value4));
    }

    [TestMethod]
    public void Exists_Null_ReturnsFalse()
    {
        // Arrange
        Node<object?> node = new(null);

        // Act & Assert
        Assert.IsFalse(node.Exists(null));
    }

    [TestMethod]
    public void Exists_ValueAndNull_ReturnsFalse()
    {
        // Arrange
        Node<string?> node = new("42");

        // Act
        node.Append(null);

        // Assert
        Assert.IsFalse(node.Exists(node.Next.Value));
    }
}