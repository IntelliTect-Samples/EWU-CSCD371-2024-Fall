namespace Assignment.Tests;
    public class SampleDataTests
    {
       [Fact]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ShouldReturnUniqueSortedStates()
        {
            // Arrange
            SampleData sampleData = new();
            var expectedStates = new List<string> { 
                "AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"
            };

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
        public void GetAggregateListOfStatesGivenPeopleCollection()
        {
            // Arrange
           SampleData sampleData = new()
           {
                CsvRows = File.ReadLines("People.csv").Skip(1).ToList()
           };
            var people = sampleData.People;
            // Act
            var expected = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
            var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);
            var resultStates = result.Split(",").ToList();

            // Assert
            Assert.Equal(expected, resultStates);
        }
        [Fact]
        public void FilterByEmailAddress_ShouldReturnFilteredEmailAddresses()
        {
            // Arrange
            SampleData sampleData = new()
            {
                CsvRows = File.ReadLines("People.csv").Skip(1)
                
            };
            Predicate<string> filter = email => email.Contains("gvitler11@comcast.net");
            var expected = new List<(string FirstName, string LastName)>
            {
                ("Gabrielle", "Vitler")
            };
            // Act
            var result = sampleData.FilterByEmailAddress(filter).ToList();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected[0].LastName, result[0].LastName);
            Assert.Equal(expected[0].FirstName, result[0].FirstName);

        }
        [Fact]
        public void PeopleObject_LINQ_ReturnsPeopleObject()
        {
            // Arrange
            SampleData sampleData = new()
            {
                CsvRows = File.ReadLines("People.csv").Skip(1)
                
            };
            IEnumerable<IPerson> people = sampleData.People;
            // Act
            List<string[]> csvRows = File.ReadLines("People.csv").Skip(1).Select(row => row.Split(',')).OrderBy(state => state[6])
            .ThenBy(city => city[5])
            .ThenBy(zip => zip[7]).ToList();
            int index = 0;
            foreach (IPerson person in people)
            {
                string[] expected = csvRows[index]; 
                string expectedFirstName = expected[1];
                string expectedLastName = expected[2];
                string expectedEmailAddress = expected[3];
                string expectedStreetAddress = expected[4];
                string expectedCity = expected[5];
                string expectedState = expected[6];
                string expectedZip = expected[7];
                Assert.Equal(expected[1], person.FirstName);
                Assert.Equal(expected[2], person.LastName);
                Assert.Equal(expected[3], person.EmailAddress);
                Assert.Equal(expected[4], person.Address.StreetAddress);
                Assert.Equal(expected[5], person.Address.City);
                Assert.Equal(expected[6], person.Address.State);
                Assert.Equal(expected[7], person.Address.Zip);
                index++;
            }
            // Assert

        }
    }