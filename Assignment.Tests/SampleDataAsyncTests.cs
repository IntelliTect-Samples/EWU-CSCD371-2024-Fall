﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;
[TestClass]
public class SampleDataAsyncTests
{
    [TestMethod]
    public async Task CsvRows_IAsyncEnumeratorDVC_ContainsAllRows()
    {
        // Arrange
        SampleDataAsync sampleData = new();
        List<string> expectedvalues = File.ReadAllLines("People.csv").Skip(1).ToList();
        // Act
        IAsyncEnumerable<string> resultEnumerable = sampleData.CsvRows;

        //  Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(resultEnumerable);
        Assert.IsTrue(await resultEnumerable.AnyAsync());
        Assert.AreEqual(expectedvalues.Count, await resultEnumerable.CountAsync());
        Assert.AreEqual('1', (await resultEnumerable.FirstAsync()).First());
        int counter = 0;

        await foreach (string value in resultEnumerable)
        {
            Assert.AreEqual(value, expectedvalues[counter]);
            counter++;
        }
    }
    [TestMethod]
    public async Task GetUniqueSortedListOfStatesGivenCsvRows_HardcodedValues_ReturnsUniqueSortedList()
    {
        //Arrange
        SampleDataAsync sampleData = new();
        List<string> expectedResult = ["AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"];
        //Act
        IAsyncEnumerable<string> resultEnumerable = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        //Assert
        Assert.IsNotNull(sampleData);
        Assert.AreEqual(expectedResult.Count, await resultEnumerable.CountAsync());

        int counter = 0;
        await foreach (string state in resultEnumerable)
        {
            Assert.AreEqual(expectedResult[counter], state);
            counter++;
        }
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateSortedList()
    {
        //Arrange
        SampleDataAsync sampleData = new();
        string expectedResult = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
        //Act
        string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        //Assert
        Assert.IsNotNull(sampleData);
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public async Task People_CSVFile_ReturnsPeople()
    {
        //Arrange
        SampleDataAsync sampleData = new();
        IAsyncEnumerable<IPerson> peopleResult = sampleData.People;
        IEnumerable<string> strings = File.ReadAllLines("People.csv").Skip(1);
        List<string[]> sortedStrings = strings.Select(row => row.Split(',')).
            OrderBy(state => state[6]).
            ThenBy(city => city[5]).
            ThenBy(zip => zip[7]).ToList();

        int counter = 0;
        string[] expectedValues;
        string expectedFirstName;
        string expectedLastName;
        string expectedEmail;
        string expectedAddress;
        string expectedCity;
        string expectedState;
        string expectedZip;
        //Act

        //Assert
        Assert.IsNotNull(peopleResult);
        Assert.IsNotNull(sortedStrings);
        Assert.AreEqual(sortedStrings.Count, await peopleResult.CountAsync());

        await foreach (IPerson person in peopleResult)
        {
            expectedValues = sortedStrings[counter];
            expectedFirstName = expectedValues[1];
            expectedLastName = expectedValues[2];
            expectedEmail = expectedValues[3];
            expectedAddress = expectedValues[4];
            expectedCity = expectedValues[5];
            expectedState = expectedValues[6];
            expectedZip = expectedValues[7];
            Assert.AreEqual(expectedFirstName, person.FirstName);
            Assert.AreEqual(expectedLastName, person.LastName);
            Assert.AreEqual(expectedEmail, person.EmailAddress);
            Assert.AreEqual(expectedAddress, person.Address.StreetAddress);
            Assert.AreEqual(expectedCity, person.Address.City);
            Assert.AreEqual(expectedState, person.Address.State);
            Assert.AreEqual(expectedZip, person.Address.Zip);
            counter++;
        }
    }

    [TestMethod]
    public async Task FilterByEmailAddress_FullEmailValue_ReturnsList()
    {
        //Arrange
        string searchValue = "fpallaske3@umich.edu";
        (string, string) expectedName = ("Fremont", "Pallaske");
        SampleDataAsync sampleData = new();
        bool predicate(string value)
        {
            return value.Contains(searchValue);
        }
        //Act
        IAsyncEnumerable<(string first, string last)> resultEnumerable =
            sampleData.FilterByEmailAddress(predicate);

        //Assert
        Assert.IsNotNull(resultEnumerable);
        Assert.AreEqual(1, await resultEnumerable.CountAsync());
        Assert.AreEqual(expectedName, await resultEnumerable.FirstAsync());
    }

    [TestMethod]
    public async Task FilterByEmailAddress_EduValue_ReturnsList()
    {
        //Arrange
        string searchValue = ".edu";
        List<(string first, string last)> expectedNames = [("Fremont", "Pallaske"), ("Sancho", "Mahony"), ("Claudell", "Leathe"), ("Issiah", "Bester"), ("Fayette", "Dougherty"),];
        int counter = 0;
        SampleDataAsync sampleData = new();

        bool predicate(string value)
        {
            return value.Contains(searchValue);
        }

        //Act
        IAsyncEnumerable<(string first, string last)> resultEnumerable =
            sampleData.FilterByEmailAddress(predicate);
        //Assert
        Assert.IsNotNull(resultEnumerable);
        Assert.AreEqual(expectedNames.Count, await resultEnumerable.CountAsync());

        await foreach ((string first, string last) in resultEnumerable)
        {
            Assert.AreEqual(expectedNames[counter].first, first);
            Assert.AreEqual(expectedNames[counter].last, last);
            counter++;
        }
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ValidPeopleEnumerable_ReturnsExpected()
    {
        //Arrange
        SampleDataAsync sample = new();
        IAsyncEnumerable<IPerson> people = sample.People;
        string expected = sample.GetAggregateSortedListOfStatesUsingCsvRows();
        //Act

        string result = sample.GetAggregateListOfStatesGivenPeopleCollection(people);
        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expected, result);
    }
}
