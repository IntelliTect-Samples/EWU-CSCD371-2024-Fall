using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_LoadDataFromCsv_SkipFirstRow()
    {
        // Arrange
        SampleData sampleData = new("People.csv");

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
        SampleData sampleData = new("People.csv");

        // Act
        List<string> states = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        string expectedState = states.OrderBy(state => state).First();

        // Assert
        Assert.IsNotNull(states);
        Assert.IsTrue(states.Count > 0);
        Assert.AreEqual(expectedState, states[0]);
        Assert.AreEqual(states.Count, states.Distinct().Count());
        Assert.IsTrue(states.SequenceEqual(states.OrderBy(s => s)), "The list should be sorted alphabetically using LINQ verification.");
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_HardCodedCsvRows_ReturnsUniqueSortedListOfStates()
    {
        // Arrange
        Mock<ISampleData> mockSampleData = new();
        mockSampleData.Setup(data => data.CsvRows).Returns(new List<string>
            {
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
                "2,John,Doe,jdoe1@example.com,1234 Elm St,Springfield,IL,62704",
                "3,Jane,Smith,jsmith2@example.com,5678 Oak St,Springfield,IL,62704",
                "4,Emily,Jones,ejones3@example.com,9101 Pine St,Helena,MT,70577",
                "5,Michael,Brown,mbrown4@example.com,1122 Maple St,Denver,CO,80203"
            });

        mockSampleData.Setup(list => list.GetUniqueSortedListOfStatesGivenCsvRows()).Returns(
            mockSampleData.Object.CsvRows
                .Select(row => row.Split(',')[6])
                .Distinct()
                .OrderBy(state => state)
        );

        // Act
        List<string> states = mockSampleData.Object.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        string expectedState = states.OrderBy(state => state).First();

        // Assert
        Assert.IsNotNull(states);
        Assert.IsTrue(states.Count > 0);
        Assert.AreEqual(expectedState, states[0]);
        Assert.AreEqual(states.Count, states.Distinct().Count());
        Assert.IsTrue(states.SequenceEqual(states.OrderBy(s => s)), "The list should be sorted alphabetically using LINQ verification.");
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void Constructor_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
    {
        // Arrange & Act
        SampleData sampleData = new("NonExistentFile.csv");

        // Assert - Expecting a FileNotFoundException
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Constructor_ShouldThrowFormatException_WhenHeaderIsNull()
    {
        // Arrange
        string fileName = "TestFile.csv";
        File.WriteAllText(fileName, "");

        try
        {
            SampleData sampleData = new(fileName);
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Constructor_ShouldThrowFormatException_WhenHeaderDoesNotMatchExpected()
    {
        // Arrange
        string fileName = "TestFile.csv";
        File.WriteAllText(fileName, "Id,FirstName,LastName,Email,Street,City,State,PostalCode");

        try
        {
            SampleData sampleData = new(fileName);
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_InputFromTestFile_ShouldReturnCommaSeparatedSortedStates()
    {
        // Arrange
        SampleData sampleData = new("People.csv");
        string actualStates = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";

        // Act
        string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.AreEqual(actualStates, result);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_UsingTestClass_ShouldReturnCommaSeparatedSortedStates()
    {
        // Arrange
        TestSampleData testSampleData = new();

        // Act
        string result = testSampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.AreEqual("CA, FL, TX", result);
    }

    [TestMethod]
    public void PeopleProperty_ValidCsvRows_ShouldReturnPersonObjects()
    {
        // Arrange
        SampleData sampleData = new("People.csv");
        Address expectedAddress = new("4718 Thackeray Pass", "Mobile", "AL", "37308");
        Person expectedPerson = new("Arthur", "Myles", expectedAddress, "amyles1c@miibeian.gov.cn");

        // Act
        var people = sampleData.People.ToList();
        var actualPerson = people.First();

        // Assert
        Assert.IsNotNull(people, "The People collection should not be null.");
        Assert.AreEqual(50, people.Count, "The size of the collection should be 50.");

        Assert.AreEqual(expectedPerson.FirstName, actualPerson.FirstName, "FirstName does not match.");
        Assert.AreEqual(expectedPerson.LastName, actualPerson.LastName, "LastName does not match.");
        Assert.AreEqual(expectedPerson.EmailAddress, actualPerson.EmailAddress, "Email does not match.");

        Assert.IsNotNull(actualPerson.Address, "Address should not be null.");
        Assert.AreEqual(expectedAddress.StreetAddress, actualPerson.Address.StreetAddress, "StreetAddress does not match.");
        Assert.AreEqual(expectedAddress.City, actualPerson.Address.City, "City does not match.");
        Assert.AreEqual(expectedAddress.State, actualPerson.Address.State, "State does not match.");
        Assert.AreEqual(expectedAddress.Zip, actualPerson.Address.Zip, "Zip does not match.");
    }

    [TestMethod]
    public void PeopleProperty_TestSampleData_ShouldReturnAllPersonsInSortedOrder()
    {
        // Arrange
        TestSampleData testSampleData = new();

        List<Person> expectedPeople = new List<Person>
        {
            new Person("John", "Doe", new Address("123 Street", "City", "CA", "12345"), "johndoe@example.com"),
            new Person("Bob", "Smith", new Address("789 Boulevard", "Village", "FL", "54321"), "bobsmith@example.com"),
            new Person("Jane", "Doe", new Address("456 Avenue", "Town", "TX", "67890"), "janedoe@example.com")
        };

        // Act
        List<IPerson> people = testSampleData.People.ToList();

        // Assert
        Assert.IsNotNull(people, "The People collection should not be null.");
        Assert.AreEqual(3, people.Count, "The People collection should contain exactly 3 people.");

        for (int i = 0; i < expectedPeople.Count; i++)
        {
            Person expected = expectedPeople[i];
            IPerson actual = people[i];

            Assert.AreEqual(expected.FirstName, actual.FirstName, $"FirstName does not match for person {i + 1}.");
            Assert.AreEqual(expected.LastName, actual.LastName, $"LastName does not match for person {i + 1}.");
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress, $"Email does not match for person {i + 1}.");

            Assert.IsNotNull(actual.Address, $"Address should not be null for person {i + 1}.");
            Assert.AreEqual(expected.Address.StreetAddress, actual.Address.StreetAddress, $"StreetAddress does not match for person {i + 1}.");
            Assert.AreEqual(expected.Address.City, actual.Address.City, $"City does not match for person {i + 1}.");
            Assert.AreEqual(expected.Address.State, actual.Address.State, $"State does not match for person {i + 1}.");
            Assert.AreEqual(expected.Address.Zip, actual.Address.Zip, $"Zip does not match for person {i + 1}.");
        }
    }

    [TestMethod]
    public void FilterByEmailAddress_ValidPredicate_ShouldReturnFilteredPersonObjects()
    {
        // Arrange
        TestSampleData testSampleData = new();
        var expectedName = ("John", "Doe");

        // Act
        var filteredNames = testSampleData.FilterByEmailAddress(email => email.Equals("johndoe@example.com", StringComparison.Ordinal));

        // Assert
        Assert.IsNotNull(filteredNames, "The filtered collection should not be null.");
        Assert.AreEqual(1, filteredNames.Count(), "The filtered collection should contain exactly 1 person.");
        var firstMatch = filteredNames.First();
        Assert.AreEqual(expectedName.Item1, firstMatch.Item1, "FirstName does not match."); // Access the first element of the tuple
        Assert.AreEqual(expectedName.Item2, firstMatch.Item2, "LastName does not match.");  // Access the second element of the tuple
    }

    [TestMethod]
    public void FilterByEmailAddress_ValidPredicate_ShouldReturnCollection()
    {
        // Arrange
        SampleData sampleData = new("People.csv");

        // Act
        IEnumerable<(string FirstName, string LastName)> filteredNames = sampleData.FilterByEmailAddress(email => email.Equals("pjenyns0@state.gov", StringComparison.Ordinal));

        // Assert
        Assert.IsNotNull(filteredNames);
        Assert.AreEqual(1, filteredNames.Count());
    }

    [TestMethod]
    public void FilterByEmailAddress_InvalidPredicate_ShouldReturnEmptyCollection()
    {
        // Arrange
        SampleData sampleData = new("People.csv");

        // Act
        IEnumerable<(string FirstName, string LastName)> filteredNames = sampleData.FilterByEmailAddress(email => email.Equals("nonexistent@example.com", StringComparison.Ordinal));

        // Assert
        Assert.IsNotNull(filteredNames);
        Assert.AreEqual(0, filteredNames.Count());
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ValidPeopleCollection_ShouldReturnCommaSeparatedStates()
    {
        // Arrange
        SampleData sampleData = new("People.csv");
        List<IPerson> people = sampleData.People.ToList();

        // Act
        string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", result);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_EmptyPeopleCollection_ShouldReturnEmptyString()
    {
        // Arrange
        SampleData sampleData = new("People.csv");
        List<IPerson> people = new();

        // Act
        string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_NullPeopleCollection_ShouldReturnEmptyString()
    {
        // Arrange
        SampleData testSampleData = new("People.csv");
        List<IPerson> people = null!;

        // Act
        string result = testSampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    private sealed class TestSampleData : ISampleData
    {
        // 1.
        private readonly List<string> _dataWithHeader =
        [
            "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip",  // Header row
            "1,John,Doe,johndoe@example.com,123 Street,City,CA,12345",
            "2,Jane,Doe,janedoe@example.com,456 Avenue,Town,TX,67890",
            "3,Bob,Smith,bobsmith@example.com,789 Boulevard,Village,FL,54321"
        ];

        // CsvRows property skips the header automatically
        public IEnumerable<string> CsvRows => _dataWithHeader.Skip(1);

        public IEnumerable<IPerson> People
        {
            get
            {
                var person = CsvRows.Select(item =>
                {
                    var columns = item.Split(',');
                    var address = new Address(columns[4], columns[5], columns[6], columns[7]);
                    return new Person(columns[1], columns[2], address, columns[3]);
                });

                return person.OrderBy(p => p.Address.State)
                             .ThenBy(p => p.Address.City)
                             .ThenBy(p => p.Address.Zip);
            }
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> states = CsvRows.Select(row => row.Split(',')[6]).Distinct();
            return states.OrderBy(state => state);
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> rowOfStates = GetUniqueSortedListOfStatesGivenCsvRows();
            return string.Join(", ", rowOfStates);
        }

        // 4.

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            return People.Where(person => filter(person.EmailAddress))
                         .Select(person => (person.FirstName, person.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}