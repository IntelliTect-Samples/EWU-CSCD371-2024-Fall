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
    public void GetSortedListOfStates_givenCsvRow_Sucess()
    {
        //Arrange
        SampleData sampleData = new();

        //Assert
        Assert.AreEqual(27, sampleData.GetAggregateSortedListOfStatesUsingCsvRows().Count());
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
        Predicate<string> filter = email => email.Contains("nasa.org");

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
        var expected = string.Join(",", stateList);
        
        var result = sampleData.GetAggregateListOfStatesGivenPeopleCollection(people);

        //Assert
        Assert.AreEqual(expected, result);
    }

}
