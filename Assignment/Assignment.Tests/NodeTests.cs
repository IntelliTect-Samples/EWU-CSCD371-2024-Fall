using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assignment;
using System.Globalization;
using System.Collections;

namespace Assignment.Tests;

[TestClass]
public class NodeTests
{

    [TestMethod]
    public void Clear_list_RemovesNodes()
    {
        // Arrange
        Node<int> node = new(99);
        node.Append(3);
        node.Append(8);

        // Act
        node.Clear();

        // Assert
        Assert.AreEqual(node, node.Next);
        Assert.AreSame(node, node.Next);
    }

    [TestMethod]
    public void Append_Value_AddsNodeToList()
    {
        // Arrange
        Node<int> node = new(8);

        // Act
        node.Append(11);
        node.Append(23);

        // Assert
        Assert.IsTrue(node.Exists(11));
        Assert.IsTrue(node.Exists(23));
        Assert.AreEqual(8, node.Value);
        Assert.AreEqual(11, node.Next.Value);
        Assert.AreEqual(23, node.Next.Next.Value);
        Assert.AreEqual(node, node.Next.Next.Next);
    }


}