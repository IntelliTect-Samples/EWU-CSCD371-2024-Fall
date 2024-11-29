using System;
using System.Collections.Generic;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1. Reads Lines from the People.csv file excluding the header
    public IEnumerable<string> CsvRows { get; set; } = File.ReadLines("People.csv").Skip(1);

    // 2. Get Unique Sorted List Of States Given CsvRows
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows.Select(row => row.Split(",")[6]).Distinct().OrderBy(state => state);
    }

    // 3. Get Aggregate Sorted List Of States Using CsvRows
    public string GetAggregateSortedListOfStatesUsingCsvRows() 
    {

        return string.Join(",", GetUniqueSortedListOfStatesGivenCsvRows());

    }

    // 4. Creates many Person from People.csv list and sorts by address
    public IEnumerable<IPerson> People 
    {
        get
        {
            return CsvRows.Select(row => row.Split(",")).Select(CurentData =>
                new Person(CurentData[1], CurentData[2],
                new Address(CurentData[4], CurentData[5], CurentData[6], CurentData[7]),
                CurentData[3]))
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
               .ThenBy(person => person.Address.Zip);
        }
    }

    // 5. Filters By Email Address
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress( Predicate<string> filter)
    {
        return People.Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));
    }

    // 6. Gets an Aggregate List Of States Given a Collection of People
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
        return people.Select(person => person.Address.State)
            .Distinct()
            .OrderBy(state => state)
            .Aggregate((current, next) => $"{current}, {next}");

    }
}
