using Microsoft.VisualStudio.TestTools.UnitTesting;

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
}