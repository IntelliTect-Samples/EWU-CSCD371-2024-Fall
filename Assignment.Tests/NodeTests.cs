using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
namespace Assignment.Tests;

[TestClass]

public class NodeTests
{
    [Fact]
    public void NodeSetValueNewNodeEqualtoValue()
    {
        // Arrange
        int value = 5;

        // Act
        Node<int> newNode = new(value);

        // Assert
        Assert.AreEqual(value, newNode.Value);

    }

    [Fact]
    public void NodeConstructorAllowsHomogenousTypesValuesEqual()
    {
        // Arrange & Act
        Node<int> intNode = new(10);
        Node<string> stringNode = new("Hello");

        // Assert
        Assert.AreEqual(typeof(Node<int>), intNode.GetType());
        Assert.AreEqual(typeof(Node<string>), stringNode.GetType());
    }

    [Fact]
    public void ToStringOverrideToStringExistsIsEqual()
    {
        // Arrange
        Node<int> intNode = new(10);

        // Act & Assert
        Assert.AreEqual("10", intNode.ToString());
    }

    [Fact]
    public void NextRefersNextNodeReturnsNextNodeValue()
    {
        // Arrange
        Node<int> intNode = new(10);

        // Act
        intNode.Append(20);

        // Assert
        Assert.AreEqual(20, intNode.Next.Value);
    }

    [Fact]
    public void AppendNextPointsBackOriginalReturnsIntNodeValue()
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
    public void ClearResetsNextNextValueThis()
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
    public void ExistsSearchForValueReturnsValueIfExists()
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
    public void AppendDuplicateValueThrowsInvalidOperationsError()
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