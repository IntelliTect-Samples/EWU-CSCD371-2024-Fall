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
        // Arrange & Act
        SampleData sampleData = new();
        IEnumerable<IPerson> peopleResult = sampleData.People;
        IEnumerable<string> csvRows = File.ReadLines("People.csv").Skip(1);
        List<string[]> sortedCsvRows = csvRows.Select(row => row.Split(','))
            .OrderBy(columns => columns[6])
            .ThenBy(columns => columns[5])
            .ThenBy(columns => columns[7])
            .ToList();

        // Assert
        int index = 0;
        foreach (IPerson person in peopleResult)
        {
            string[] expectedValues = sortedCsvRows[index++];
            Assert.Equal(expectedValues[1], person.FirstName);
            Assert.Equal(expectedValues[2], person.LastName);            
            Assert.Equal(expectedValues[3], person.EmailAddress);          
            Assert.Equal(expectedValues[4], person.Address.StreetAddress);  
            Assert.Equal(expectedValues[5], person.Address.City);           
            Assert.Equal(expectedValues[6], person.Address.State);          
            Assert.Equal(expectedValues[7], person.Address.Zip);           
        }
    }

    [Fact]
    public void FilterByEmailAddress_GivenEmailAddress_ReturnsListOfFilteredNames()
    {
        // Arrange
        SampleData sampleData = new();
        sampleData.CsvRows = File.ReadLines("People.csv").Skip(1); // Load People.csv and skip the header
        
        // Act
        Predicate<string> emailFilter = email => email.Contains("cbucklej@tiny.cc");

        var filteredNames = sampleData.FilterByEmailAddress(emailFilter).ToList();

        // Assert
        Assert.NotNull(filteredNames);
    }


}