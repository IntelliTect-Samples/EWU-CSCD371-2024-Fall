using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [Fact]
    public void SkipFirstRow_CsvRows_Sucess()
    {
        //Arrange
        SampleData sampleData = new();
        //Act
        IEnumerable<String> CsvRows = sampleData.CsvRows;
        string firstrow = CsvRows.First();
        //Assert
        Assert.AreNotEqual(firstrow, "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");

    }

    [Fact]
    public void GetSortedListOfStates_GivenCsvRow_Sucess()
    {
        //Arrange
        SampleData sampleData = new();

        //Assert
        Assert.AreEqual(27, sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Count());
    }

    [Fact]
    public void GetAggergateSortedListOfStates_UseingCsvRows_Sucess()
    {
        //Arrange
        SampleData sampleDate = new();
        String expected = ("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV");

        //Act
        String result = sampleDate.GetAggregateSortedListOfStatesUsingCsvRows();

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Fact]
    public void MakePersonList_People_ReturnsPersonCollection()
    {
        //Arrange
        SampleData sampleData = new();

        //Act
        IEnumerable<IPerson> people = sampleData.People;

        //Assert
        Assert.AreEqual(50, people.Count());
        Assert.AreEqual("Daile", people.ElementAt(25).FirstName);
        Assert.AreEqual("Pallaske", people.ElementAt(12).LastName);
        Assert.AreEqual("hdorra@exblog.jp", people.ElementAt(6).EmailAddress);
        Assert.AreEqual("69152", people.ElementAt(3).Address.Zip);
    }
    [Fact]
    public void filterByEmail_EmailAddress_Sucess()
    {
        //Arrange
        SampleData sampleData = new();
        // filter for nasa email 
        Predicate<string> filter = email => email.Contains("nasa.gov");

        //Act
        var result = sampleData.FilterByEmailAddress(filter);
        var first = result.First();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Ev", first.FirstName);
        Assert.AreEqual("Challace", first.LastName);
    }

    [Fact]
    public void GetAggregateListOfStates_GivenPeopleCollection_ReturnSucessfuly()
    {
        //Arrange
        SampleData sampleData = new();
        var people = sampleData.People;

        //Act
        var stateList = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        var expected = string.Join(", ", stateList);

        var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [Fact]
    public void GetUniqueSortedListOfStatesGivenHarcodeData_GivenCsvRoew_Success()
    {
        //Arrange
        SampleData sampleData = new();
        List<string> csvData = [
            "1,bob,joe,bobjoe@place.org,8675 North Bute Street,Lakewood Prairie,WA,30900",
            "2,Korie,Cole,colestopper@trains.org,1627 Ty Merchant,Starlight Cove,OR,14598",
            "3,Sunfields,Pineboots,sunny@forestprotect.gov,144656 Whitehorse Pend,Whispering Pines River,MI,66895",
            "4,Luys,FeralWraith,Luyswraith@wraithleagel.com,12122 Bannerdale Close,Willowbrooke Ridge,KS,46567",
            "5,Aarynn,Gardiner,agardiner@copany.com,159753 S Matson Court,Starview Cove,OR,55230",
            "6,Raven,Blaze,blazingBird@yahoo.com,14765 Avon Bridge,Cedar Mill Crossing,KS,76958"];

        sampleData.CsvRows = csvData;

        //Act
        var result = sampleData.GetUniqueSortedListOfStatesGivenCsvRows().ToList();
        var expected = new List<string> { "KS", "MI", "OR", "WA" };

        //Assert
        CollectionAssert.AreEqual(expected, result);
    }

}
