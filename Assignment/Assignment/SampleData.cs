﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        /*
            Property to read lines from the CSV file "People.csv". The first line (header) is skipped.
            This uses File.ReadLines to avoid loading the entire file into memory, which is useful for large files.
        */
        public IEnumerable<string> CsvRows { get; set; } = File.ReadLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            /*
                Process each row, splitting it into columns and extracting the state (7th column, index 6).
                The Trim method ensures no leading or trailing whitespace in the state names.
                The Distinct method removes duplicate state entries.
                The OrderBy method sorts the states alphabetically.
            */
            IEnumerable<string> states = CsvRows
                .Select(row => row.Split(",")[6].Trim())
                .Distinct()
                .OrderBy(state => state);

            return states; // Return the final list of unique, sorted states.
        }
        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

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
