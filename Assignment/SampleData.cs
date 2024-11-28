using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows {get; set;} = File.Exists("People.csv") ? File.ReadAllLines("People.csv").Skip(1) : throw new FileNotFoundException("The file People.csv was not found.");

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() => CsvRows
            .Select(row => row.Split(',')[6])
            .Distinct()
            .OrderBy(state => state);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());
        

        // 4.
        public IEnumerable<IPerson> People => CsvRows
            .Select(row => row.Split(','))
            .Select(row => new Person(row[1].Trim(), row[2].Trim(), new Address(row[4].Trim(), row[5].Trim(), row[6].Trim(), row[7].Trim()), row[3].Trim()))
            .OrderBy(person => person.Address.State)
            .ThenBy(person => person.Address.City)
            .ThenBy(person => person.Address.Zip);
        
        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter) => People
            .Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) => people
                .Select(person => person.Address.State)
                .Distinct()
                .OrderBy(state => state)
                .Aggregate((current, next) => $"{current},{next}");
       
    }
}
