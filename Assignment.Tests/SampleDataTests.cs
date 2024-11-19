namespace Assignment.Tests;

public class SampleDataTests
{
    [Fact]
    public void SkippingFirstRow_PeopleCSV_Successful()
    {
        SampleData data = new SampleData();
        IEnumerable<string> csvRows = data.CsvRows;
        string firstRow = csvRows.First();
        Assert.DoesNotContain(firstRow, "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
    }
    
    [Fact]
    public void GetUniqueSortedListOfStates_GivenCsvFile_Successful()
    {
        // Arrange
        SampleData sampleData = new SampleData();

        // Act
        IEnumerable<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        List<string> expectedStates = new List<string> {
            "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", 
            "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", 
            "TX", "UT", "VA", "WA", "WV"
        };
        
        Assert.Equal(expectedStates, result);
    }


}