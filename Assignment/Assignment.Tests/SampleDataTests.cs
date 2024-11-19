using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public void GetUniqueSortedListOfStatesGivenCsvRows_ShouldReturnUniqueSortedStates()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        var uniqueSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        var expectedStates = new List<string> { "CA", "FL", "GA", "MT", "TX" }; // Corrected expected states
        CollectionAssert.AreEqual(expectedStates, uniqueSortedStates.ToList(), "The unique sorted list of states is incorrect.");
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_Linq_ShouldReturnUniqueSortedStates()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        var uniqueSortedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        var isSorted = uniqueSortedStates.SequenceEqual(uniqueSortedStates.OrderBy(state => state));
        Assert.IsTrue(isSorted, "States aren't sorted alphabetically.");
    }

    [TestMethod]
    public void People_ShouldBeOrderedByStateCityAndZip()
    {
        // Arrange
        var sampleData = new SampleDataForTesting(GetHardcodedCsvRows());

        // Act
        var people = sampleData.People.ToList();

        // Assert
        Assert.AreEqual("CA", people[0].Address.State);
        Assert.AreEqual("Long Beach", people[0].Address.City);
        Assert.AreEqual("59721", people[0].Address.Zip);
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
