using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    private static List<string> GetHardcodedCsvRows()
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
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedStates()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        IEnumerable<string> uniqueSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        var expectedStates = new List<string> { "CA", "FL", "GA", "MT", "TX" };
        CollectionAssert.AreEqual(expectedStates, uniqueSortedStates.ToList(), "The unique sorted list of states is incorrect.");
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_LinqSampleData_ReturnsUniqueSortedStates()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        IEnumerable<string> uniqueSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        bool isSorted = uniqueSortedStates.SequenceEqual(uniqueSortedStates.OrderBy(state => state));

        // Assert
        Assert.IsTrue(isSorted, "States aren't sorted alphabetically.");
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_LinqPeopleCollection_ReturnsUniqueSortedStates()
    {
        // Arrange
        SampleData sampleData = new();
        IEnumerable<string> people = File.ReadAllLines("People.csv").Skip(1);
        
        // Act
        List<string> expectedResult = people
            .Select(row => row.Split(',')[6])
            .Distinct()
            .OrderBy(state => state)
            .ToList();
        IEnumerable<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        CollectionAssert.AreEqual(expectedResult, result.ToList(), "The unique sorted list of states is incorrect.");
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateSortedStates()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        string aggregateSortedStates = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        // Assert
        Assert.AreEqual("CA, FL, GA, MT, TX", aggregateSortedStates);
    }

    [TestMethod]
    public void People_ShouldReturnCorrectNumOfPeople()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        List<IPerson> people = sampleData.People.ToList();
        // Assert
        Assert.AreEqual(5, people.Count);
    }

    [TestMethod]
    public void People_ShouldReturnCorrectPeople()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        List<IPerson> people = sampleData.People.ToList();
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
    public void FilterByEmailAddress_ShouldReturnCorrectPeople()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        // Act
        List<(string FirstName, string LastName)> people = sampleData.FilterByEmailAddress(email => email.Contains("state.gov")).ToList();
        // Assert
        Assert.AreEqual(1, people.Count);
        Assert.AreEqual("Priscilla", people[0].FirstName);
        Assert.AreEqual("Jenyns", people[0].LastName);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsAggregateListOfStates()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());
        IEnumerable<IPerson> people = sampleData.People;
        // Act
        string aggregateListOfStates = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        string expectedStates = String.Join(", ", sampleData.GetUniqueSortedListOfStatesGivenCsvRows());
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
