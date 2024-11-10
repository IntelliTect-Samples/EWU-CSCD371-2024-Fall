using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_LoadDataFromCsv_SkipFirstRow()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        List<string> csvRows = sampleData.CsvRows.ToList();

        // Assert
        Assert.IsNotNull(csvRows);
        Assert.IsTrue(csvRows.Count > 0);
        Assert.AreEqual("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577", csvRows[0]);
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_GivenCsvRows_ReturnsUniqueSortedListOfStates()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        List<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        string expectedState = states.OrderBy(state => state).First();

        // Assert
        Assert.IsNotNull(states);
        Assert.IsTrue(states.Count > 0);
        Assert.AreEqual(expectedState, states[0]);
        Assert.AreEqual(states.Count, states.Distinct().Count());
    }
}