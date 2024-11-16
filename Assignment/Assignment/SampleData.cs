using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public virtual IEnumerable<string> CsvRows
    {
        get
        {
            return File.Exists("People.csv") ? File.ReadLines("People.csv").Skip(1) : Enumerable.Empty<string>();
        }
    }

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
           .Select(row => row.Split(',')[6])
           .Distinct()
           .OrderBy(state => state)
           .ToList();
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        var statesArray = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        return string.Join(", ", statesArray);
    }

    // 4.
    public IEnumerable<IPerson> People
    {
        get
        {
            return CsvRows
                .Select(row => row.Split(','))
                .Select(columns => new Person(
                    columns[0],
                    columns[1],
                    new Address(
                        columns[2],
                        columns[3],
                        columns[4],
                        columns[5]
                    ),
                    columns[6]
                ))
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip);
        }
    }

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter)
    {
        return People
            .Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
        var uniqueSortedStates = people
            .Select(person => person.Address.State)
            .Distinct()
            .OrderBy(state => state)
            .Aggregate((current, next) => $"{current}, {next}");

        return uniqueSortedStates;
    }
}
