using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_Initialized_IsNotNull()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.IsNotNull(sampleData.CsvRows);
    }

    [TestMethod]
    public void CsvRows_Initialized_CorrectCount()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreEqual(sampleData.CsvRows.Count(), 50);
    }

    [TestMethod]
    public void CsvRows_Initialized_FirstRowRemoved()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreNotEqual("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", sampleData.CsvRows.First());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_Called_ReturnsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreEqual(27,sampleData.GetUniqueSortedListOfStatesGivenCsvRows
            ().Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_Called_SortsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.IsTrue(sampleData.GetUniqueSortedListOfStatesGivenCsvRows().First()[0] < sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Last()[0]);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStates_Called_ReturnsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
    }
}
