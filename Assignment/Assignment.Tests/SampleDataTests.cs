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
            "John,Doe,123 Main St,Springfield,IL,62701,john.doe@example.com", // Row 1
            "Jane,Smith,456 Oak St,Chicago,IL,60601,jane.smith@example.com", // Row 2
            "Alice,Johnson,789 Pine St,Peoria,IL,61602,alice.johnson@example.com", // Row 3
            "Bob,Williams,321 Birch St,Chicago,IL,60602,bob.williams@example.com", // Row 4
            "Charlie,Brown,654 Cedar St,New York,NY,10001,charlie.brown@example.com" // Row 5
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
        var expectedStates = new List<string> { "IL", "NY" }; // The states from the hardcoded rows
        CollectionAssert.AreEqual(expectedStates, uniqueSortedStates.ToList(), "The unique sorted list of states is incorrect.");
    }
}

public class SampleDataForTesting : SampleData
{
    private readonly IEnumerable<string> _csvRows;

    public SampleDataForTesting(IEnumerable<string> csvRows)
    {
        _csvRows = csvRows;
    }

    public new IEnumerable<string> CsvRows => _csvRows;
}
