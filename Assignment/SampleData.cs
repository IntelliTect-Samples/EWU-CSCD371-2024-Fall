using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment;

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

            return CsvRows.Select(row => row.Split(",")[6].Trim())
                .Distinct()
                .OrderBy(state => state);
        }
        
        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            // Call the method to get the unique sorted states and convert them into an array.
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();

            // Use string.Join to concatenate all states into a single string, separated by commas.
            string aggregate = string.Join(", ", states);
            return aggregate; // Return the aggregated string of states.
        }

    // 4.
    public IEnumerable<IPerson> People
    {
        get
        {
            return CsvRows
                .Select(row =>
                {
                    var columns = row.Split(',');

                    var address = new Address(
                        columns[4].Trim(),
                        columns[5].Trim(),
                        columns[6].Trim(),
                        columns[7].Trim()
                    );

                    return new Person(
                        columns[1].Trim(),
                        columns[2].Trim(),
                        address,
                        columns[3].Trim()
                    );
                })
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip);
        }
    }

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter predicate cannot be null.");
        }

        return People
            .Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }

