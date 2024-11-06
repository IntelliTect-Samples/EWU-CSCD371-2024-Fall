using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericsHomeworkTests;

[TestClass]
public class VennDiagramTests
{
    // VennDiagram Construction
    #region VennConstructionTests

    [TestMethod]
    public void VennDiagramConstruction_NegativeNumOfCirclesPassed_ThrowsException()
    {
        // Assert
        Assert.ThrowsException<ArgumentException>(() => new VennDiagram<string>(-5));
    }

    [TestMethod]
    public void VennDiagramConstruction_ZeroCirclesPassed_ThrowsException()
    {
        // Assert
        Assert.ThrowsException<ArgumentException>(() => new VennDiagram<string>(0));
    }

    #endregion

    // GetCircle
    #region GetCircleTests

    [TestMethod]
    public void GetCircle_NegativeIndex_ThrowsException()
    {
        // Arrange
        VennDiagram<string> venn = new(1);
        var index = -43;

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => venn.GetCircle(index));
    }

    [TestMethod]
    public void GetCircle_IndexGreaterThanSize_ThrowsException()
    {
        // Arrange
        VennDiagram<string> venn = new(1);
        var index = 53;

        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => venn.GetCircle(index));
    }

    #endregion

    // AddItem (¿null item?)
    #region AddItemTests

    [TestMethod]
    public void AddItem_AddUniqueItem_Passes()
    {
        VennDiagram<string> venn = new(1);
        var expected = "A";
        venn.AddItem(expected, [0]);

        Assert.AreEqual<object>(expected, venn.GetCircle(0).Items.First());
    }

    [TestMethod]
    public void AddItem_AddUniqueItemToMultipleCircles_Passes()
    {
        VennDiagram<string> venn = new(2);
        venn.AddItem("A", [0, 1]);

        Assert.AreEqual<object>(venn.GetCircle(0).Items.First(), venn.GetCircle(1).Items.First());
    }

    [TestMethod]
    public void AddItem_AddNullItem_ThrowsException()
    {
        VennDiagram<string> venn = new(2);
        Assert.ThrowsException<ArgumentNullException>(() => venn.AddItem(null!, [0, 1]));
    }

    #endregion

    // GetAllItems
    #region GetAllItemsTests

    [TestMethod]
    public void GetAllItems_EmptyCircles_ReturnsZeroItems()
    {
        // Arrange
        VennDiagram<string> venn = new(3);
        var expectedItems = 0;
        // Assert
        Assert.AreEqual<object>(expectedItems, venn.GetAllItems().Count());
    }


    [TestMethod]
    public void GetAllItems_UniqueItemsInEachCircle_Passes()
    {
        // Arrange
        VennDiagram<string> venn = new(2);
        // Act
        venn.AddItem("A", [0]);
        venn.AddItem("B", [1]);
        venn.AddItem("C", [0, 1]); // 1 unique Item added to both circles
        // Assert
        Assert.AreEqual<object>(3, venn.GetAllItems().Count()); // 4 items total, 3 distinct
    }

    #endregion

    // GetUniqueToCircle
    #region GetUniqueToCircleTests

    [TestMethod]
    public void GetUniqueToCircle_NoUniqueItems_ReturnsZero()
    {
        // Arrange
        VennDiagram<string> venn = new(3);
        var expectedItems = 0;
        // Act
        venn.AddItem("A", [0, 1, 2]);
        venn.AddItem("B", [0, 1, 2]);
        venn.AddItem("C", [0, 1, 2]);
        // Assert
        Assert.AreEqual<object>(expectedItems, venn.GetUniqueToCircle(2).Count());
    }

    [TestMethod]
    public void GetUniqueToCircle_OneUniqueItem_ReturnsOne()
    {
        // Arrange
        VennDiagram<string> venn = new(3);
        var expectedItems = 1;
        // Act
        venn.AddItem("A", [0, 1, 2]);
        venn.AddItem("B", [0, 1, 2]);
        venn.AddItem("C", [2]); // "C" is unique to the third circle
        // Assert
        Assert.AreEqual<object>(expectedItems, venn.GetUniqueToCircle(2).Count());
    }

    #endregion
}
