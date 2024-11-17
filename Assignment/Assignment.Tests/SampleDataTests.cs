using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Security;
using System.Xml;

namespace Assignment.Tests;


//We understand that logic in tests is typically frowned upon, but the assignment recommends we don't use collection assertions,
//Thus we must iterate :)


[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_IEnumeratorEVC_ContainsAllRows()
    {
        // Arrange
        SampleData sampleData = new(File.ReadAllLines("People.csv"));
        List<string> expectedvalues = File.ReadAllLines("People.csv").Skip(1).ToList();
        // Act
        IEnumerable<string> resultEnumerable = sampleData.CsvRows;

        //  Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(resultEnumerable);
        Assert.IsTrue(sampleData.CsvRows.Any());
        Assert.AreEqual(expectedvalues.Count, resultEnumerable.Count());
        Assert.AreEqual('1', resultEnumerable.First().First());
        int counter = 0;

        foreach (string value in expectedvalues)
        {
            Assert.AreEqual(value, expectedvalues[counter]);
            counter++;
        }
    }



    [TestMethod]
    public void CsvRows_DVC_ContainsAllRows()
    {
        //Arrange
        SampleData sampleData = new();
        List<string> expectedValues = File.ReadAllLines("People.csv").Skip(1).ToList();
        //Act

        //Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(expectedValues);
        Assert.AreEqual(expectedValues.Count, sampleData.CsvRows.Count());
        Assert.IsTrue(sampleData.CsvRows.Any());

        Assert.AreEqual('1', sampleData.CsvRows.First().First());

        int counter = 0;
        foreach (string value in sampleData.CsvRows)
        {
            Assert.AreEqual(value, expectedValues[counter]);
            counter++;
        }
    }


    [TestMethod]
    public void CsvRows_StringEVC_ContainsAllRows()
    {
        //Arrange
        SampleData sampleData = new("People.csv");
        List<string> expectedValues = File.ReadAllLines("People.csv").Skip(1).ToList();
        //Act

        //Assert
        Assert.IsNotNull(sampleData);
        Assert.IsNotNull(expectedValues);
        Assert.AreEqual(expectedValues.Count, sampleData.CsvRows.Count());
        Assert.IsTrue(sampleData.CsvRows.Any());

        Assert.AreEqual('1', sampleData.CsvRows.First().First());

        int counter = 0;
        foreach (string value in sampleData.CsvRows)
        {
            Assert.AreEqual(value, expectedValues[counter]);
            counter++;
        }
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_HardcodedValues_ReturnsUniqueSortedList()
    {
        //Arrange
        SampleData sampleData = new();
        List<string> expectedResult = ["AL", "AZ", "CA", "DC", "FL", "GA", "IN", "KS", "LA", "MD", "MN", "MO", "MT", "NC", "NE", "NH", "NV", "NY", "OR", "PA", "SC", "TN", "TX", "UT", "VA", "WA", "WV"];
        //Act
        IEnumerable<string> resultEnumerable = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();
        //Assert
        Assert.IsNotNull(sampleData);
        Assert.AreEqual(expectedResult.Count, resultEnumerable.Count());

        int counter = 0;
        foreach (string state in resultEnumerable)
        {
            Assert.AreEqual(expectedResult[counter], state);
            counter++;
        }
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_GivenSoftList_ReturnsUniqueSortedList()
    {
        //Arrange
        SampleData sampleData = new();
        IEnumerable<string> fileLines = File.ReadAllLines("People.csv").Skip(1);
        IEnumerable<string> expectedResult = fileLines
            .Select(row => row.Split(',')[6].Trim())
            .Distinct()
            .OrderBy(state => state);
        List<string> expectedResults = expectedResult.ToList();


        //Act
        IEnumerable<string> resultEnumerable = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

        //Assert
        Assert.AreEqual(expectedResults.Count, resultEnumerable.Count());

        int counter = 0;
        foreach (string state in resultEnumerable)
        {
            Assert.AreEqual(expectedResults[counter], state);
            counter++;
        }
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_ReturnsAggregateSortedList()
    {
        //Arrange
        SampleData sampleData = new();
        string expectedResult = "AL, AZ, CA, DC, FL, GA, IN, KS, LA, MD, MN, MO, MT, NC, NE, NH, NV, NY, OR, PA, SC, TN, TX, UT, VA, WA, WV";
        //Act
        string result = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        //Assert
        Assert.IsNotNull(sampleData);
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void People_CSVFile_ReturnsPeople()
    {
        //Arrange
        SampleData sampleData = new();
        IEnumerable<IPerson> peopleResult = sampleData.People;
        IEnumerable<string> strings = File.ReadAllLines("People.csv").Skip(1);
        List<string[]> sortedStrings = strings.Select(row => row.Split(',')).
            OrderBy(state => state[6]).
            ThenBy(city => city[5]).
            ThenBy(zip => zip[7]).ToList();


        int counter = 0;
        string[] expectedValues;
        string expectedFirstName;
        string expectedLastName;
        string expectedEmail;
        string expectedAddress;
        string expectedCity;
        string expectedState;
        string expectedZip;
        //Act


        //Assert
        Assert.IsNotNull(peopleResult);
        Assert.IsNotNull(sortedStrings);
        Assert.AreEqual(peopleResult.Count(), sortedStrings.Count);

        foreach (IPerson person in peopleResult)
        {
            expectedValues = sortedStrings[counter];
            expectedFirstName = expectedValues[1];
            expectedLastName = expectedValues[2];
            expectedEmail = expectedValues[3];
            expectedAddress = expectedValues[4];
            expectedCity = expectedValues[5];
            expectedState = expectedValues[6];
            expectedZip = expectedValues[7];
            Assert.AreEqual(expectedFirstName, person.FirstName);
            Assert.AreEqual(expectedLastName, person.LastName);
            Assert.AreEqual(expectedEmail, person.EmailAddress);
            Assert.AreEqual(expectedAddress, person.Address.StreetAddress);
            Assert.AreEqual(expectedCity, person.Address.City);
            Assert.AreEqual(expectedState, person.Address.State);
            Assert.AreEqual(expectedZip, person.Address.Zip);
            counter++;
        }


    }

}