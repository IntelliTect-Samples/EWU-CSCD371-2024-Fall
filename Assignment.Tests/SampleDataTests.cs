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

        // Assert
        Assert.IsTrue(sampleData.GetUniqueSortedListOfStatesGivenCsvRows().First()[0] < sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Last()[0]);
    }

    //[TestMethod]
    //public void GetUniqueSortedListOfStates_Called_LinqVerifiesSorted()
    //{
    //    // Arrange
    //    SampleData sampleData = new();

    //    // Act
    //    IEnumerable<string> sortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
    //    IEnumerable<string> test = from state in sortedStates
    //                               where sortedStates.ElementAt(0)
    //                               select state;
    //    // Assert
    //    Assert.IsTrue(sampleData.GetUniqueSortedListOfStatesGivenCsvRows().First()[0] < sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Last()[0]);
    //}

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
        Assert.AreEqual("MT", result.First().Address.State); 

        // Additional validation using CsvRows
        var firstPerson = result.First();
        Assert.AreEqual(firstCsvRow[1], firstPerson.FirstName); 
        Assert.AreEqual(firstCsvRow[2], firstPerson.LastName); 
        Assert.AreEqual(firstCsvRow[3], firstPerson.EmailAddress);
        Assert.AreEqual(firstCsvRow[4], firstPerson.Address.StreetAddress);
        Assert.AreEqual(firstCsvRow[5], firstPerson.Address.City);
        Assert.AreEqual(firstCsvRow[6], firstPerson.Address.State);
        Assert.AreEqual(firstCsvRow[7], firstPerson.Address.Zip);
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
