﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => File.Exists("People.csv") ? File.ReadAllLines("People.csv").Skip(1) : throw new FileNotFoundException("The file People.csv was not found.");

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() => CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows() => string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());
        

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
