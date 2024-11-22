using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        string csvData = "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip" + Environment.NewLine +
                         "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577" + Environment.NewLine +
                         "2,John,Doe,jdoe@example.com,123 Main St,Anytown,CA,90210" + Environment.NewLine +
                         "3,Jane,Smith,jsmith@example.com,456 Oak St,Somewhere,TX,73301";

        string fileName = "TestFile.csv";

        File.WriteAllText(fileName, csvData);

        try
        {
            SampleData sampleData = new(fileName);

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
        finally
        {
            File.Delete(fileName);
        }
    }

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void Constructor_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
    {
        // Arrange

        // Act
        _ = new SampleData("NonExistentFile.csv");

        // Assert - Expecting a FileNotFoundException
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Constructor_InvalidHeader_ShouldThrowInvalidFormatException()
    {
        // Arrange
        string fileName = "TestFile.csv";
        File.WriteAllText(fileName, "FirstName");

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
    public void PeopleProperty_ValidCsvRows_ShouldReturnPersonObjects()
    {
        // Arrange
        SampleData sampleData = new("People.csv");
        Address expectedAddress = new("4718 Thackeray Pass", "Mobile", "AL", "37308");
        Person expectedPerson = new("Arthur", "Myles", expectedAddress, "amyles1c@miibeian.gov.cn");

        // Act
        List<IPerson> people = sampleData.People.ToList();
        IPerson actualPerson = people.First();

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
        List<IPerson> people = [];

        // Act
        string result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    // TODO: Fix tests from the extra credit refactor
    /*[TestMethod]
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

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetAggregateListOfStatesGivenPeopleCollection_InvalidPeopleCollection_ShouldThrowInvalidOperationException()
    {
        // Arrange
        SampleData testSampleData = new("People.csv");
        List<IPerson> people =
        [
            new Person("John", "Doe", new Address("123 Main St", "Anytown", "Anystate", "12345"), "jdoe@example.com")
        ];

        // Act
        _ = testSampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert - Expecting an InvalidOperationException
    }*/
}