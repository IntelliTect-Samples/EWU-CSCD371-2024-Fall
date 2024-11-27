using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Assignment.Tests;

[TestClass]

public class NodeTests
{
    [Fact]
    public void Node_SetValue_newNodeEqualtoValue()
    {
        // Arrange
        int value = 5;

        // Act
        Node<int> newNode = new(value);

        // Assert
        Assert.AreEqual(value, newNode.Value);

    }

    [Fact]
    public void NodeConstructor_AllowsHomogenousTypes_ValuesEqual()
    {
        // Arrange & Act
        Node<int> intNode = new(10);
        Node<string> stringNode = new("Hello");

        // Assert
        Assert.AreEqual(typeof(Node<int>), intNode.GetType());
        Assert.AreEqual(typeof(Node<string>), stringNode.GetType());
    }

    [Fact]
    public void ToString_OverrideToString_ExistsIsEqual()
    {
        // Arrange
        Node<int> intNode = new(10);

        // Act & Assert
        Assert.AreEqual("10", intNode.ToString());
    }

    [Fact]
    public void Next_RefersNextNode_ReturnsNextNodeValue()
    {
        // Arrange
        Node<int> intNode = new(10);

        // Act
        intNode.Append(20);

        // Assert
        Assert.AreEqual(20, intNode.Next.Value);
    }

    [Fact]
    public void Append_NextPointsBackOriginal_ReturnsIntNodeValue()
    {
        // Arrange
        Node<int> intNode = new(10);

        // Act
        intNode.Append(20);
        intNode.Next.Append(30);

        // Assert
        Assert.AreEqual(10, intNode.Next.Next.Next.Value);
    }

    [Fact]
    public void Clear_ResetsNext_NextValueThis()
    {
        // Arrange
        Node<int> nodeOne = new(10);
        nodeOne.Append(20);
        nodeOne.Next.Append(30);

        // Act
        nodeOne.Clear();

        // Assert
        Assert.AreEqual(10, nodeOne.Next.Value);
    }

    [Fact]
    public void Exists_SearchForValue_ReturnsValueIfExists()
    {
        // Arrange
        Node<string> nodeOne = new("one");
        nodeOne.Append("Two");
        nodeOne.Next.Append("Three");
        nodeOne.Next.Next.Append("Four");

        // Act
        bool exists = nodeOne.Exists("Three");

        // Assert
        Assert.IsTrue(exists);
    }

    [Fact]
    public void Append_DuplicateValue_ThrowsInvalidOperationsError()
    {
        // Arrange
        Node<int> intNode = new(10);
        intNode.Append(20);
        intNode.Next.Append(30);
        intNode.Next.Next.Append(40);

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => intNode.Append(30));
    }



}