using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class SampleDataAsyncTests
{
    [TestMethod]
    public async Task GetCsvRowsAsync_ValidFile_ShouldReturnAllRows()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");

        // Act
        List<string> csvRows = await sampleData.GetCsvRowsAsync().ToListAsync();

        // Assert
        Assert.IsNotNull(csvRows);
        Assert.IsTrue(csvRows.Count > 0);
        Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", csvRows[0]);
    }

    [TestMethod]
    public async Task GetUniqueSortedListOfStates_GivenCsvRows_ShouldReturnUniqueSortedListOfStates()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");

        // Act
        List<string> states = await sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToListAsync();

        // Assert
        Assert.IsNotNull(states);
        Assert.IsTrue(states.Count > 0);
        Assert.AreEqual(states.Count, states.Distinct().Count());
        Assert.IsTrue(states.SequenceEqual(states.OrderBy(s => s)), "The list should be sorted alphabetically.");
    }

    [TestMethod]
    public async Task GetAggregateSortedListOfStatesUsingCsvRows_Given_ShouldReturnCommaSeparatedSortedStates()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");
        string expectedStates = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";

        // Act
        string result = await sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.AreEqual(expectedStates, result);
    }

    [TestMethod]
    public async Task GetPeopleAsync_ValidCsvRows_ShouldReturnPersonObjects()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");
        Address expectedAddress = new("4718 Thackeray Pass", "Mobile", "AL", "37308");
        Person expectedPerson = new("Arthur", "Myles", expectedAddress, "amyles1c@miibeian.gov.cn");

        // Act
        List<IPerson> people = await sampleData.GetPeopleAsync().ToListAsync();
        IPerson actualPerson = people.First();

        // Assert
        Assert.IsNotNull(people, "The People collection should not be null.");
        Assert.AreEqual(50, people.Count, "The size of the collection should be 50.");

        Assert.AreEqual(expectedPerson.FirstName, actualPerson.FirstName, "FirstName does not match.");
        Assert.AreEqual(expectedPerson.LastName, actualPerson.LastName, "LastName does not match.");
        Assert.AreEqual(expectedPerson.EmailAddress, actualPerson.EmailAddress, "Email does not match.");

        Assert.IsNotNull(actualPerson.Address, "Address should not be null.");
        Assert.AreEqual(expectedAddress.StreetAddress, actualPerson.Address.StreetAddress, "StreetAddress does not match.");
        Assert.AreEqual(expectedAddress.City, actualPerson.Address.City, "City does not match.");
        Assert.AreEqual(expectedAddress.State, actualPerson.Address.State, "State does not match.");
        Assert.AreEqual(expectedAddress.Zip, actualPerson.Address.Zip, "Zip does not match.");
    }

    [TestMethod]
    public async Task FilterByEmailAddress_ValidPredicate_ShouldReturnFilteredCollection()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");

        // Act
        List<(string FirstName, string LastName)> filteredNames = await sampleData.FilterByEmailAddress(email => email.Equals("pjenyns0@state.gov", StringComparison.Ordinal)).ToListAsync();

        // Assert
        Assert.IsNotNull(filteredNames);
        Assert.AreEqual(1, filteredNames.Count);
    }

    [TestMethod]
    public async Task FilterByEmailAddress_InvalidPredicate_ShouldReturnEmptyCollection()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");

        // Act
        List<(string FirstName, string LastName)> filteredNames = await sampleData.FilterByEmailAddress(email => email.Equals("nonexistent@example.com", StringComparison.Ordinal)).ToListAsync();

        // Assert
        Assert.IsNotNull(filteredNames);
        Assert.AreEqual(0, filteredNames.Count);
    }

    [TestMethod]
    public async Task GetAggregateListOfStates_GivenPeopleCollection_ValidPeopleCollection_ShouldReturnCommaSeparatedStates()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");
        List<IPerson> people = await sampleData.GetPeopleAsync().ToListAsync();

        // Act
        string result = await sampleData.GetAggregateListOfStatesGivenPeopleCollection(people.ToAsyncEnumerable());

        // Assert
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", result);
    }

    [TestMethod]
    public async Task GetAggregateListOfStates_GivenPeopleCollection_EmptyPeopleCollection_ShouldReturnEmptyString()
    {
        // Arrange
        SampleDataAsync sampleData = new("People.csv");
        IAsyncEnumerable<IPerson> emptyPeople = Enumerable.Empty<IPerson>().ToAsyncEnumerable();

        // Act
        string result = await sampleData.GetAggregateListOfStatesGivenPeopleCollection(emptyPeople);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }
}