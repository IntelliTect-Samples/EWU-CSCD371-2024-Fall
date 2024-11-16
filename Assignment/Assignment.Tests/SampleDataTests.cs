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
            // Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
            "1,John,Doe,john.doe@example.com,123 Main St,Springfield,IL,62701", // Row 1
            "2,Jane,Smith,jane.smith@example.com,456 Oak St,Chicago,IL,60601", // Row 2
            "3,Alice,Johnson,alice.johnson@example.com,789 Pine St,Peoria,AZ,85001", // Row 3
            "4,Bob,Williams,bob.williams@example.com,321 Birch St,Houston,TX,77001", // Row 4
            "5,Charlie,Brown,charlie.brown@example.com,654 Cedar St,New York,NY,10001" // Row 5
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
        var expectedStates = new List<string> { "AZ", "IL", "NY", "TX" }; // The states from the hardcoded rows
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

    public override IEnumerable<string> CsvRows => _csvRows;
}
