using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment;
using System.Globalization;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [DataTestMethod]
    [DataRow(1)]
    [DataRow(11231)]
    public void Constructor_ValidInput_CreatesValidNode_Int(int value)
    {
        // Act
        Node<int> node = new(value);

        // Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(value, node.Value);
    }

    [DataTestMethod]
    [DataRow("MyDataValue")]
    [DataRow("AnotherValue")]
    public void Constructor_ValidInput_CreatesValidNode_String(string value)
    {
        // Act
        Node<string> node = new(value);

        // Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(value, node.Value);
    }

    [TestMethod]
    public void Constructor_NullInput_CreatesValidNode()
    {
        // Act
        Node<object> node = new(null);

        // Assert
        Assert.IsNotNull(node);
        Assert.IsNull(node.Value);
    }

    [TestMethod]
    public void SimpleTest()
    {
        Assert.IsTrue(true);
    }

    // ... other code ...

    [DataTestMethod]
    [DataRow(1)]
    [DataRow(2)]
    public void ToString_ValidCall_ReturnsString_Int(int val)
    {
        // Arrange
        Node<int> node = new(val);

        // Act & Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(val.ToString(CultureInfo.InvariantCulture), node.ToString());
    }

    [DataTestMethod]
    [DataRow("SomeData")]
    [DataRow("AnotherData")]
    public void ToString_ValidCall_ReturnsString_String(string val)
    {
        // Arrange
        Node<string> node = new(val);

        // Act & Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(val.ToString(), node.ToString());
    }

    [TestMethod]
    public void Next_NoSet_ReturnsBaseNode()
    {
        // Arrange
        Node<int> node = new(1);

        // Act & Assert
        Assert.IsNotNull(node);
        Assert.IsNotNull(node.Next);
        Assert.AreEqual(node, node.Next);
        Assert.AreSame(node, node.Next);
    }

    [TestMethod]
    public void Append_ValidChange_AddsNodeAfterCurrent()
    {
        // Arrange
        Node<int> node = new(1);

        // Act
        node.Append(2);
        node.Append(3);

        // Assert
        Assert.IsNotNull(node);
        Assert.IsNotNull(node.Next);
        Assert.IsNotNull(node.Next.Next);
        Assert.AreEqual(1, node.Value);
        Assert.AreEqual(3, node.Next.Value);
        Assert.AreEqual(2, node.Next.Next.Value);
        Assert.AreSame(node, node.Next.Next.Next);
    }

    [DataTestMethod]
    [DataRow(1, 2, 3, 3, true)]
    [DataRow(1, 2, 3, 4, false)]
    public void Exists_ValidInput_ReturnsTrue_Int(int val, int val2, int val3, int expectedValue, bool expectedResult)
    {
        // Arrange
        Node<int> node = new(val);
        node.Append(val2);
        node.Append(val3);

        // Act
        bool exists = node.Exists(expectedValue);

        // Assert
        Assert.AreEqual(expectedResult, exists);
    }

    [DataTestMethod]
    [DataRow("SomeData", "AnotherData", "ThirdData", "AnotherData", true)]
    [DataRow("SomeData", "AnotherData", "ThirdData", "NotPresent", false)]
    public void Exists_ValidInput_ReturnsTrue_String(string val, string val2, string val3, string expectedValue, bool expectedResult)
    {
        // Arrange
        Node<string> node = new(val);
        node.Append(val2);
        node.Append(val3);

        // Act
        bool exists = node.Exists(expectedValue);

        // Assert
        Assert.AreEqual(expectedResult, exists);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_DuplicateValues_ThrowsException()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);

        // Act
        node.Append(1); // This should throw
    }

    [TestMethod]
    public void Clear_ValidLoop_RemovesNodes()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
        Assert.AreSame(node, node.Next);
    }

    [TestMethod]
    public void GetEnumerator_ValidLoop_ReturnsEnumerator()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);
        // Act
        IEnumerator<int> enumerator = node.GetEnumerator();
        // Assert
        Assert.IsNotNull(enumerator);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual(1, enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual(3, enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual(2, enumerator.Current);
        Assert.IsFalse(enumerator.MoveNext());
    }
}