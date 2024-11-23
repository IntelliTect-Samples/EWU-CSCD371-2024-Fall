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

}