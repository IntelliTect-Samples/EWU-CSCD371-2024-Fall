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
    public void GetUniqueSortedListOfStates_GivenCsvFile_VerifiesSortingAndUniqueness()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        List<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList(); // Materialize the collection

        // Assert
        // Verify that the result is sorted alphabetically
        Assert.True(result.SequenceEqual(result.OrderBy(state => state)), "The list is not sorted alphabetically.");

        // Verify that the result contains unique items
        Assert.Equal(result.Count, result.Distinct().Count()); // Count is a property for lists
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
        SampleData sampleData = new()
        {
            CsvRows = File.ReadLines("People.csv").Skip(1)
        };

        Predicate<string> emailFilter = email => email.Contains("echallaceu@nasa.gov");
        var expectedResult = new List<(string FirstName, string LastName)>
        {
            ("Ev", "Challace")
        };


        // Act
        var filteredNames = sampleData.FilterByEmailAddress(emailFilter).ToList();

        // Assert
        Assert.NotNull(filteredNames);
        Assert.Equal(expectedResult[0].FirstName, filteredNames[0].FirstName);
        Assert.Equal(expectedResult[0].LastName, filteredNames[0].LastName);
    }

    [Fact]
    public void GetAggregateListOfStatesGivenPeopleCollection_PeopleCSV_ReturnsListOfStates()
    {
        // Arrange
        SampleData sampleData = new()
        {
            CsvRows = File.ReadLines("People.csv").Skip(1).ToList() // Materialize the CsvRows collection
        };

        var people = sampleData.People; // Assume People is already processed and materialized
        var expectedStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList(); // Materialize the expected states

        // Act
        var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
        var resultStates = result.Split(", ").ToList(); // Split the aggregated states string into a list

        // Assert
        Assert.NotNull(result); // Ensure the result is not null
        Assert.Equal(expectedStates.Count, resultStates.Count); // Ensure the counts match
        Assert.True(expectedStates.SequenceEqual(resultStates), "The states do not match the expected sorted and unique list.");
    }
}