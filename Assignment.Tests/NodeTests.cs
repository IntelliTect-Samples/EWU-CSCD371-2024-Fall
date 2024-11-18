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

        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("val1", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("Why", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("hello", enumerator.Current);
        Assert.IsTrue(enumerator.MoveNext());
        Assert.AreEqual("there", enumerator.Current);
        Assert.IsFalse(enumerator.MoveNext());

    }

    [TestMethod]
    public void ChildItems_ValidNodes_ReturnsValues()
    {
        //Arrange
        Node<string> node = new("val1");
        node.Append("Why");
        node.Append("hello");
        node.Append("there");

        //Act
        IEnumerable<string> enumerable = node.ChildItems(2);
        List<string> resultList = enumerable.ToList();

        //Assert
        Assert.AreEqual(2, enumerable.Count());

        Assert.AreEqual("val1", resultList[0]);
        Assert.AreEqual("Why", resultList[1]);
    }



}