namespace Assignment.Tests;
    public class SampleDataTests
    {
        [Fact]
        public void CsvRows_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            // Arrange
            var sampleData = new SampleData();

            // Act
            Action act = () => sampleData.CsvRows.ToList();

            // Assert
            Assert.Throws<FileNotFoundException>(act);
        }

       [Fact]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ShouldReturnUniqueSortedStates()
        {
            // Arrange
            SampleData sampleData = new();
            var expectedStates = new List<string> { "CA", "NY", "TX" };

            // Act
            var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            // Assert
            Assert.Equal(expectedStates, result);
        }
        [Fact]
        public void GetAggregateSortedListOfStatesUsingCsvRows()
        {
            // Arrange
            SampleData sampleData = new();
            IEnumerable<string> result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
            List <string> expectedStates = new(){ 
                "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"
             };
            Assert.Equal(expectedStates, result);
        }
               [Fact]
        public void Test_GetAggregateListOfStatesGivenPeopleCollection()
        {
            // Arrange
           SampleData sampleData = new SampleDataTest()
           {
                CsvRows = File.ReadLines("People.csv").Skip(1).ToList()
           };
            var people = sampleData.People;
            // Act
            var expected = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

            // Assert
            Assert.AreEqual(string.Join(",", expected), result);
        }
    }