using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;


//We understand that logic in tests is typically frowned upon, but the assignment recommends we don't use collection assertions,
//Thus we must iterate :)


[TestClass]
public class NodeTests
{

    [TestMethod]
    public void GetEnumerator()
    {
        //Arrange
        Node<string> node = new("val1");

        node.Append("Why");
        node.Append("hello");
        node.Append("there");
        //Act
        IEnumerator<string> enumerator = node.GetEnumerator();


        //Assert
        Assert.AreEqual("val1", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("Why", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("hello", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("there", enumerator.Current);
        Assert.IsFalse(enumerator.MoveNext());

    }
}