using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void CreateSingleNode_PointsToSelf_True()
    {
        // Arrange
        var node = new Node<int>(42);

        // Assert
        Assert.AreEqual(node, node.Next);
    }

    [TestMethod]
    public void Node_ToString_ReturnsValue()
    {
        // Arrange
        var node = new Node<int>(42);

        // Assert
        Assert.AreEqual("42", node.ToString());
    }

    [TestMethod]
    public void Append_ListSizeOne_Success()
    {
        // Arrange
        var node = new Node<int>(42);

        // Act
        node.Append(43);

        // Assert
        Assert.AreEqual(43, node.Next.Value);
        Assert.AreEqual(node, node.Next.Next);
    }

    [TestMethod]
    public void Append_ListMoreThanOne_Success()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);

        // Act
        node.Append(44);

        // Assert
        Assert.AreEqual(43, node.Next.Next.Value);
        Assert.AreEqual(node, node.Next.Next.Next);
    }

    [TestMethod]
    public void Append_DuplicateValue_ThrowsException()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => node.Append(43));
    }

    [TestMethod]
    public void GetEnumerator_ToList_Success()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);
        node.Append(44);
        // Act
        var result = node.ToList();
        // Assert
        CollectionAssert.AreEqual(new List<int> { 42, 44, 43 }, result);
    }

    [TestMethod]
    public void ChildItems_ToList_Success()
    {
        // Arrange
        var node = new Node<int>(42);
        node.Append(43);
        node.Append(44);
        // Act
        IEnumerable<int> result = node.ChildItems(2);
        foreach (int item in result)
        {
            Console.WriteLine(item);
        }
        //Assert
        CollectionAssert.AreEqual(new List<int> { 42, 44 }, result.ToList());
    }
}