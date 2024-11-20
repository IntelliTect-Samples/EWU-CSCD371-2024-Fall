namespace Assignment.Tests;

public class SampleDataTests
{
    [Fact]
    public void SkippingFirstRow_PeopleCSV_Successful()
    {
        SampleData data = new();
        IEnumerable<string> csvRows = data.CsvRows;
        string firstRow = csvRows.First();
        Assert.DoesNotContain(firstRow, "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
    }
    
    [Fact]
    public void GetUniqueSortedListOfStates_GivenCsvFile_Successful()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        IEnumerable<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        List<string> expectedStates = new() {
            "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", 
            "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", 
            "TX", "UT", "VA", "WA", "WV"
        };
        
        Assert.Equal(expectedStates, result);
    }
    
    [Fact]
    public void GetAggregateSortedListOfStatesUsingCsvRows_GivenCsvFile_Successful()
    {
        // Arrange
        SampleData sampleData = new ();

        // Act
        string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        string expectedAggregate = 
            "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, " +
            "MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, " +
            "SC, TN, TX, UT, VA, WA, WV";

        Assert.Equal(expectedAggregate, result);
    }

    [Fact]
    public void PeopleProperty_PeopleCSV_ReturnsPeopleObject()
    {
        // Arrange
        SampleData sampleData = new();
        IEnumerable<IPerson> peopleResult = sampleData.People;

        // Read and sort the CSV rows
        IEnumerable<string> csvRows = File.ReadLines("People.csv").Skip(1);
        List<string[]> sortedCsvRows = csvRows.Select(row => row.Split(','))
            .OrderBy(columns => columns[6]) // State
            .ThenBy(columns => columns[5]) // City
            .ThenBy(columns => columns[7]) // Zip
            .ToList();

        // Assert that the collections are non-null and have matching counts
        Assert.NotNull(peopleResult);
        Assert.NotNull(sortedCsvRows);
        Assert.Equal<int>(sortedCsvRows.Count, peopleResult.Count());
    }

}