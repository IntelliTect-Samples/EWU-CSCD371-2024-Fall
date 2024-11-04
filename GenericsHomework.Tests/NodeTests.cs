using Xunit;

namespace GenericsHomework.Tests;

public class NodeTests
{
    [Fact]
    public void Node_SetValue_newNodeEqualtoValue()
    {
        // Arrange
        int value = 5;

        // Act
        Node<int> newNode = new Node<int>(value);

        // Assert
        Assert.Equal(value, newNode.Value);

    }

    [Fact]
    public void NodeConstructor_AllowsHomogenousTypes_ValuesEqual()
    {
        // Arrange & Act
        Node<int> intNode = new Node<int>(10);
        Node<string> stringNode = new Node<string>("Hello");

        // Assert
        Assert.Equal(typeof(Node<int>), intNode.GetType());
        Assert.Equal(typeof(Node<string>), stringNode.GetType());
    }

    [Fact]
    public void ToString_OverrideToString_ExistsIsEqual()
    {
        // Arrange
        Node<int> intNode = new Node<int>(10);

        // Act & Assert
        Assert.Equal("10", intNode.ToString());
    }

    [Fact]
    public void Next_RefersNextNode_ReturnsNextNodeValue()
    {
        // Arrange
        Node<int> intNode = new Node<int>(10);

        // Act
        intNode.Append(20);

        // Assert
        Assert.Equal(20, intNode.Next.Value);
    }

    [Fact]
    public void Append_NextPointsBackOriginal_ReturnsIntNodeValue()
    {
        // Arrange
        Node<int> intNode = new Node<int>(10);

        // Act
        intNode.Append(20);
        intNode.Next.Append(30);

        // Assert
        Assert.Equal(10, intNode.Next.Next.Next.Value);
    }

    [Fact]
    public void Clear_ResetsNext_NextValueThis()
    {
        // Arrange
        Node<int> nodeOne = new Node<int>(10);
        nodeOne.Append(20);
        nodeOne.Next.Append(30);

        // Act
        nodeOne.Clear();

        // Assert
        Assert.Equal(10, nodeOne.Next.Value);
    }

    [Fact]
    public void Exists_SearchForValue_ReturnsValueIfExists()
    {
        // Arrange
        Node<string> nodeOne = new Node<string>("one");
        nodeOne.Append("Two");
        nodeOne.Next.Append("Three");
        nodeOne.Next.Next.Append("Four");

        // Act
        bool exists = nodeOne.Exists("Three");

        // Assert
        Assert.True(exists);
    }



}