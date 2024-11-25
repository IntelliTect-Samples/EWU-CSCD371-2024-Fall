namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_LoadData_SkipsFirstRow()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        IEnumerable<string> csvRows = sampleData.CsvRows;

        // Assert
        Assert.AreNotEqual("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", csvRows.First());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedList_Success()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        IEnumerable<string> uniqueSortedListOfStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV", 
                         string.Join(", ", uniqueSortedListOfStates));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsUniqueSortedListFromHardcodedData_Success()
    {
        // Arrange
        SampleData sampleData = new()
        {
            CsvRows = HardcodedCsvData()
        };

        // Act
        IEnumerable<string> uniqueSortedListOfStates = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        // Assert
        Assert.AreEqual("CA, MA, NY, WA", string.Join(", ", uniqueSortedListOfStates));
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateSortedList()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        string aggregateSortedListOfStates = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        // Assert
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV",
                         aggregateSortedListOfStates);
    }

    [TestMethod]
    public void People_LoadData_ReturnsPeopleCollection()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        IEnumerable<IPerson> people = sampleData.People;

        // Assert
        Assert.AreEqual(50, people.Count());
        Assert.AreEqual("Amelia", people.ElementAt(49).FirstName);
        Assert.AreEqual("Toal", people.ElementAt(49).LastName);
        Assert.AreEqual("atoall@fema.gov", people.ElementAt(49).EmailAddress);
        Assert.AreEqual("44302", people.ElementAt(49).Address.Zip);
    }

    [TestMethod]
    public void FilterByEmailAddress_ReturnsFilteredCollection()
    {
        // Arrange
        SampleData sampleData = new();

        // Act
        IEnumerable<(string FirstName, string LastName)> filteredCollection =
            sampleData.FilterByEmailAddress(email => email.Contains("japanpost.jp"));

        // Assert
        Assert.AreEqual(1, filteredCollection.Count());
        Assert.AreEqual("Vince", filteredCollection.First().FirstName);
        Assert.AreEqual("Dee", filteredCollection.First().LastName);
    }

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollection_ReturnsAggregateListOfStates()
    {
        // Arrange
        SampleData sampleData = new();
        IEnumerable<IPerson> people = sampleData.People;

        // Act
        string aggregateListOfStates = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        // Assert
        Assert.AreEqual("AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV",
                         aggregateListOfStates);
    }

    private static List<String> HardcodedCsvData() => [
            "1,John,Doe,johndoe@email.com,123 Main St,Anytown,CA,12345",
            "2,Peter,Parker,spiderman@marvel.org,456 Elm St,New York,NY,54321",
            "3,Megan,Smith,idk@qwerty.com,789 Oak St,Los Angeles,CA,67890",
            "4,Tom,Brady,goat@nfl.com,1010 Maple St,Boston,MA,11223",
            "5,Jenn,Jenson,asdf@postal.net,1212 Pine St,Seattle,WA,33445",
        ];
}
