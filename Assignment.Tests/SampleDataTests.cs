using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    private IEnumerable<string> GetHardcodedCsvRows()
    {
        return new List<string>
        {
            "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721",
            "4,Fremont,Pallaske,fpallaske3@umich.edu,16958 Forster Crossing,Atlanta,GA,10687",
            "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Dallas,TX,88632"
        };
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedStates_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        var uniqueSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        var expectedStates = new List<string> { "CA", "FL", "GA", "MT", "TX" };
        CollectionAssert.AreEqual(expectedStates, uniqueSortedStates.ToList(), "The unique sorted list of states is incorrect.");
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_Linq_ReturnsUniqueSortedStates_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        var uniqueSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        var isSorted = uniqueSortedStates.SequenceEqual(uniqueSortedStates.OrderBy(state => state));
        Assert.IsTrue(isSorted, "States aren't sorted alphabetically.");
    }

    //TODO: Add a test for GetAggregateSortedListOfStatesUsingCsvRows
    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateSortedStates_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        var aggregateSortedStates = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        // Assert
        Assert.AreEqual("CA, FL, GA, MT, TX", aggregateSortedStates);
    }

    [TestMethod]
    public void People_ShouldReturnCorrectNumOfPeople_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        var people = sampleData.People.ToList();
        // Assert
        Assert.AreEqual(5, people.Count);
    }

    [TestMethod]
    public void People_ShouldReturnCorrectPeople_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        var people = sampleData.People.ToList();
        // Assert
        Assert.AreEqual("Chadd", people[0].FirstName);
        Assert.AreEqual("Stennine", people[0].LastName);
        Assert.AreEqual("cstennine2@wired.com", people[0].EmailAddress);
        Assert.AreEqual("94148 Kings Terrace", people[0].Address.StreetAddress);
        Assert.AreEqual("Long Beach", people[0].Address.City);
        Assert.AreEqual("CA", people[0].Address.State);
        Assert.AreEqual("59721", people[0].Address.Zip);
    }

    [TestMethod]
    public void FilterByEmailAddress_ShouldReturnCorrectPeople_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        var people = sampleData.FilterByEmailAddress(email => email.Contains("state.gov")).ToList();
        // Assert
        Assert.AreEqual(1, people.Count);
        Assert.AreEqual("Priscilla", people[0].FirstName);
        Assert.AreEqual("Jenyns", people[0].LastName);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsAggregateListOfStates_Success()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        var people = sampleData.People;
        // Act
        var aggregateListOfStates = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        var expectedStates = String.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows());
        // Assert
        Assert.AreEqual(expectedStates, aggregateListOfStates);
    }
}

public class SampleDataForTesting : SampleData
{
    private readonly IEnumerable<string> _csvRows;

    public SampleDataForTesting(IEnumerable<string> csvRows)
    {
        _csvRows = csvRows;
    }

    public override IEnumerable<string> CsvRows => _csvRows;
}
