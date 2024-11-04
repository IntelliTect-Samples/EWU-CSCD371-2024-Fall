using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomework;

public class NodeTests
{
    // Test to string
        // null(?) node
        // list with 1 node
        // list with a few nodes

    [TestMethod]
    public void ToString_NullNode_ReturnsNull()
    {
        Node<string> newNode = null;
        //var value = newNode?.ToString();
        Assert.ThrowsException<NullReferenceException>(() => newNode?.ToString());
    }

    [TestMethod]
    public void ToString_EmptyNode_Passes()
    {
        Node<string> newNode = new("HelloWorld");
        var compareVal = "HelloWorld";
        Assert.AreEqual(compareVal, newNode.ToString());
    }

    // Test Append
    // null(?) node
    // list with 1 node
    // list with a few nodes

    // Test Clear
    // null(?) node
    // list with 1 node
    // list with a few nodes

    // Test Exists
    // null(?) node
    // list with 1 node
    // list with a few nodes

    // Test Value/Next properties?
}
