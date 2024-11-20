using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [DataTestMethod]
    [DataRow(1)]
    [DataRow(11231.2)]
    [DataRow("MyDataValue")]
    [DataRow(null)]
    public void Constructor_ValidInput_CreatesValidNode<T>(T value)
    {
        // Act
        Node<T> node = new(value);

        // Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(typeof(Node<T>), node.GetType());
        Assert.AreEqual(value, node.Value);
    }

    [DataTestMethod]
    [DataRow(1)]
    [DataRow("SomeData")]
    [DataRow(null)]
    public void ToString_ValidCall_ReturnsString<T>(T val)
    {
        // Arrange
        Node<T> node = new(val);

        // Act & Assert
        Assert.IsNotNull(node);
        Assert.AreEqual(val?.ToString(), node.ToString());
    }

    [DataTestMethod]
    [DataRow(1)]
    [DataRow("SomeData")]
    [DataRow(null)]
    public void Next_NoSet_ReturnsBaseNode<T>(T val)
    {
        // Arrange
        Node<T> node = new(val);

        // Act & Assert
        Assert.IsNotNull(node);
        Assert.IsNotNull(node.Next);
        Assert.AreEqual(node, node.Next);
        Assert.AreSame(node, node.Next);
    }

    [DataTestMethod]
    [DataRow(1, 2, 3)]
    [DataRow("SomeData", "21", "thirdValue")]
    [DataRow(45.6, null, 43.5)]
    public void Append_ValidChange_ReturnsExpected<T>(T val, T val2, T val3)
    {
        // Arrange
        Node<T> node = new(val);
        node.Append(val3);

        // Act
        node.Append(val2);

        // Assert
        Assert.IsNotNull(node);
        Assert.IsNotNull(node.Next);
        Assert.IsNotNull(node.Next.Next);
        Assert.AreEqual(val, node.Value);
        Assert.AreEqual(val2, node.Next.Value);
        Assert.AreEqual(val3, node.Next.Next.Value);
        Assert.AreSame(node, node.Next.Next.Next);
    }

    [DataTestMethod]
    [DataRow(1, 2, 3, 3, true)]
    [DataRow(1, 2, 3, 13, false)]
    [DataRow("SomeData", "21", "thirdValue", "21", true)]
    [DataRow("SomeData", "21", "thirdValue", "22", false)]
    [DataRow("SomeData", "21", "thirdValue", null, false)]
    [DataRow(null, 32.5, 42.1, null, true)]
    public void Exists_ValidInput_ReturnsTrue<T>(T val, T val2, T val3, T expectedValue, bool expectedResult)
    {
        // Arrange
        Node<T> node = new(val);
        node.Append(val2);
        node.Append(val3);

        // Act
        bool exists = node.Exists(expectedValue);

        // Assert
        Assert.AreEqual(expectedResult, exists);
    }

    [DataTestMethod]
    [DataRow(1, 3, 1)]
    [DataRow("SomeData", "21", "SomeData")]
    [DataRow(null, "data", null)]
    [DataRow("data", null, null)]
    [DataRow(1.0, 2.8, 2.8)]
    public void Append_DuplicateValues_ThrowsException<T>(T val, T val2, T val3)
    {
        // Arrange
        Node<T> node = new(val);
        node.Append(val2);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => node.Append(val3));
    }

    [DataTestMethod]
    [DataRow(1, 3, 2)]
    [DataRow("SomeData", "21", "SomeData2")]
    [DataRow(null, "data2", "data")]
    [DataRow("data", null, "t")]
    [DataRow(1.0, 2.8, 2.9)]
    public void Clear_ValidLoop_RemovesNodes<T>(T val, T val2, T val3)
    {
        // Arrange
        Node<T> node = new(val);
        node.Append(val2);
        node.Append(val3);
        Node<T> node2 = node.Next;
        Node<T> node3 = node2.Next;

        // Act
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
        Assert.AreSame(node, node.Next);
        Assert.AreSame(node2.Next, node2);
        Assert.AreSame(node3.Next, node3);
        Assert.AreEqual(node2, node2.Next);
        Assert.AreEqual(node3, node3.Next);
    }
}