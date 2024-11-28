﻿using System;
using System.Collections.Generic;

namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows { get; set; } = File.ReadAllLines("People.csv").Skip(1);

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() => CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state);

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows() => string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows().ToArray());

    // 4.
    public IEnumerable<IPerson> People => CsvRows.Select(row => row.Split(','))
                .Select(columns =>
                new Person(columns[1], columns[2],
                new Address(columns[4], columns[5], columns[6], columns[7]),
                columns[3]))
                .OrderBy(person => person.Address.State)
                .ThenBy(person => person.Address.City)
                .ThenBy(person => person.Address.Zip);

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter) => People.Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people) => people.Select(person => person.Address.State)
            .Distinct()
            .OrderBy(state => state)
            .Aggregate((current, next) => $"{current}, {next}");
}
