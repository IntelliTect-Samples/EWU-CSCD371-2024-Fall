using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    [TestMethod]
    public void CsvRows_Initialized_IsNotNull()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.IsNotNull(sampleData.CsvRows);
    }

    [TestMethod]
    public void CsvRows_Initialized_CorrectCount()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreEqual(sampleData.CsvRows.Count(), 50);
    }

    [TestMethod]
    public void CsvRows_Initialized_FirstRowRemoved()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreNotEqual("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip", sampleData.CsvRows.First());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_Called_ReturnsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreEqual(27,sampleData.GetUniqueSortedListOfStatesGivenCsvRows
            ().Count());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStates_Called_SortsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.IsTrue(sampleData.GetUniqueSortedListOfStatesGivenCsvRows().First()[0] < sampleData.GetUniqueSortedListOfStatesGivenCsvRows().Last()[0]);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStates_Called_ReturnsCorrectly()
    {
        // Arrange
        SampleData sampleData = new();

        // Act

        // Assert
        Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", sampleData.GetAggregateSortedListOfStatesUsingCsvRows());
    }

    [TestMethod]
    public void People_UsingCsvRows_Success()
    {
        // Arrange
        SampleData sampleData = new();
        List<string> cvsRows = 
            [
            "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
            "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
            "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721",
            "4,Fremont,Pallaske,fpallaske3@umich.edu,16958 Forster Crossing,Atlanta,GA,10687",
            "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Dallas,TX,88632",
            "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,33 Menomonie Trail,Atlanta,GA,10687"
            ];

        sampleData.CsvRows = csvRows;
        // Act
        IEnumerable<IPerson> result = sampleData.People;
        // Assert
        IEnumerable<IPerson> expected = [];
        expected = expected.Append(new Person("Chadd", "Stennine", new Address("94148 Kings Terrace", "Long Beach", "CA", "59721"), "cstennine2@wired.com"));
        expected = expected.Append(new Person("Karin", "Joder", new Address("03594 Florence Park", "Tampa", "FL", "71961"), "kjoder1@quantcast.com"));
        expected = expected.Append(new Person("Priscilla", "Jenyns", new Address("7884 Corry Way", "Helena", "MT", "70577"), "pjenyns0@state.gov"));
        expected = expected.Append(new Person("Fremont", "Pallaske", new Address("16958 Forster Crossing", "Atlanta", "GA", "10687"), "fpallaske3@umich.edu"));
        expected = expected.Append(new Person("Melisa", "Kerslake", new Address("283 Pawling Parkway", "Dallas", "TX", "88632"), "mkerslake4@dion.ne.jp"));

    }

}
