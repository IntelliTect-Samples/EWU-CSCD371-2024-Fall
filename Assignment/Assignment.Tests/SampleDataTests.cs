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
        File.WriteAllText(fileName, ""); // Create an empty file to simulate null header

        try
        {
            // Act
            SampleData sampleData = new(fileName);
        }
        finally
        {
            // Cleanup
            File.Delete(fileName);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Constructor_ShouldThrowFormatException_WhenHeaderDoesNotMatchExpected()
    {
        // Arrange
        string fileName = "TestFile.csv";
        File.WriteAllText(fileName, "Id,FirstName,LastName,Email,Street,City,State,PostalCode"); // Incorrect header format

        try
        {
            // Act
            SampleData sampleData = new(fileName);
        }
        finally
        {
            // Cleanup
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
        Address expectedAddress = new("7884 Corry Way", "Helena", "MT", "70577");
        Person expectedPerson = new("Priscilla", "Jenyns", expectedAddress, "pjenyns0@state.gov");

        // Act
        var people = sampleData.People.ToList(); // Materialize the collection
        var actualPerson = people.First();      // Get the first person in the collection

        // Assert
        // Validate collection size
        Assert.IsNotNull(people);
        Assert.AreEqual(50, people.Count, "The size of the collection should be 50.");

        // Validate first person's details
        Assert.AreEqual(expectedPerson.FirstName, actualPerson.FirstName, "FirstName does not match.");
        Assert.AreEqual(expectedPerson.LastName, actualPerson.LastName, "LastName does not match.");
        Assert.AreEqual(expectedPerson.EmailAddress, actualPerson.EmailAddress, "Email does not match.");

        // Validate address details
        Assert.IsNotNull(actualPerson.Address, "Address should not be null.");
        Assert.AreEqual(expectedAddress.StreetAddress, actualPerson.Address.StreetAddress, "StreetAddress does not match.");
        Assert.AreEqual(expectedAddress.City, actualPerson.Address.City, "City does not match.");
        Assert.AreEqual(expectedAddress.State, actualPerson.Address.State, "State does not match.");
        Assert.AreEqual(expectedAddress.Zip, actualPerson.Address.Zip, "Zip does not match.");
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
        public IEnumerable<IPerson> People => throw new NotImplementedException();

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}