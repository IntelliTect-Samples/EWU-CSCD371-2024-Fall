using System;
using System.Collections.Generic;
using System.Linq;
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
        var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        var expectedSortedStates = result.OrderBy(state => state).ToList();


        // Assert
        Assert.IsTrue(result.SequenceEqual(expectedSortedStates));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_Called_HardCodedVerifiesSorted()
    {
        // Arrange
        SampleData sampleData = new();
        List<string> csvRows =
    [
        "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
        "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
        "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721"
    ];
        sampleData.CsvRows = csvRows;

        // Act
        var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();  // Ensure it's a List
        var expectedStates = new List<string> { "CA", "FL", "MT" };


        // Assert the lists are equal
        CollectionAssert.AreEqual(expectedStates, result);
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

    [TestMethod]
    public void People_UsingCsvRows_Success()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        var result = sampleData.People;

        var firstCsvRow = sampleData.CsvRows.First().Split(',');

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
        Assert.AreEqual(50, result.Count());
        Assert.AreEqual("AL", result.First().Address.State);
        Assert.AreEqual("Mobile", result.First().Address.City);
        Assert.AreEqual("37308", result.First().Address.Zip);

    }

    [TestMethod]
    public void FilterByEmailAddress_ValidFilter_ReturnsMatchingNames()
    {
        // Arrange
        SampleData sampleData = new();
        Predicate<string> filter = email => email.Contains("quantcast.com");

        // Act
        var result = sampleData.FilterByEmailAddress(filter);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsTrue(result.Any());
        var firstMatch = result.First();
        Assert.AreEqual("Karin", firstMatch.FirstName);
        Assert.AreEqual("Joder", firstMatch.LastName);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();
        var people = sampleData.People;

        // Get the unique sorted list of states
        var expectedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        var expectedResult = string.Join(", ", expectedStates);

        // Act
        var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedResult, result);
    }

}
