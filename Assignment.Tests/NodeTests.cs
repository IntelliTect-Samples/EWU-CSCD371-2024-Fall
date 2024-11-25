using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void Append_AddNodeToList_Success()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);

        // Assert
        Assert.AreEqual(2, node.Next.Value);
    }

    [TestMethod]
    public void Append_AddNodeToEndOfList_Success()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);
        node.Append(3);

        // Assert
        Assert.AreEqual(2, node.Next.Value);
        Assert.AreEqual(3, node.Next.Next.Value);

    }

    [TestMethod]
    public void Append_AddDuplicateNodeToList_ThrowsException()
    {
        // Arrange
        var node = new Node<int>(1);

        // Assert
        Assert.ThrowsException<InvalidOperationException>(() => node.Append(1));
    }

    [TestMethod]
    public void Exists_NodeExistsInList_ReturnsTrue()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);

        // Assert
        Assert.IsTrue(node.Exists(2));
    }

    [TestMethod]
    public void Exists_NodeDoesNotExistInList_ReturnsFalse()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);
        // Assert
        Assert.IsFalse(node.Exists(3));
    }

    [TestMethod]
    public void Clear_ClearList_Success()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
    }

    [TestMethod]
    public void GetEnumerator_GetListItems_Success()
    {
        // Arrange
        Node<int> node = new Node<int>(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);

        var expectedValues = new List<int> { 1, 2, 3, 4 };

        // Act
        var actualValues = node.ToList();

        // Assert
        Assert.IsNotNull(actualValues);
        CollectionAssert.AreEqual(expectedValues, actualValues);
    }

    [TestMethod]
    public void ChildItems_GetRemainingItemLessThanMaximum_Success()
    {
        // Arrange
        Node<int> node = new Node<int>(1);
        node.Append(2);
        node.Append(3);
        node.Append(4);

        // Act
        IEnumerable<int> test = node.ChildItems(3);
        int count = test.Count();
        

        // Assert
        Assert.AreEqual(3, count);
    }
}
