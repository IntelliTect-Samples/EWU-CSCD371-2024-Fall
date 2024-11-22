﻿namespace Assignment;

public class SampleDataAsync : SampleDataBase, IAsyncSampleData
{
    public SampleDataAsync(string fileName) : base(fileName)
    {
        ValidateAndReadHeader(); // Ensure file and header are valid
    }

    public StreamReader GetReader()
    {
        return new(FileName);
    }

    public async IAsyncEnumerable<string> GetCsvRowsAsync()
    {
        using StreamReader reader = new(FileName);
        string? header = await reader.ReadLineAsync();
        if (header is null or not CsvHelper.ExpectedHeader)
        {
            throw new FormatException($"Invalid header: {header}");
        }

        while (!reader.EndOfStream)
        {
            string? line = await reader.ReadLineAsync();
            if (line is not null) // Ensure we don't yield null values
            {
                yield return line;
            }
        }
    }

    public async IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        HashSet<string> states = [];
        await foreach (string row in GetCsvRowsAsync())
        {
            string state = CsvHelper.ParseRow(row)[6];
            if (states.Add(state))
            {
                yield return state;
            }
        }
    }

    public async Task<string> GetAggregateSortedListOfStatesUsingCsvRows()
    {
        List<string> states = [];
        await foreach (string state in GetUniqueSortedListOfStatesGivenCsvRows())
        {
            states.Add(state);
        }
        states.Sort();
        return string.Join(", ", states);
    }

    public async IAsyncEnumerable<IPerson> GetPeopleAsync()
    {
        await foreach (string row in GetCsvRowsAsync())
        {
            string[] columns = CsvHelper.ParseRow(row);
            Address address = new(columns[4], columns[5], columns[6], columns[7]);
            yield return new Person(columns[1], columns[2], address, columns[3]);
        }
    }

    public async IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        await foreach (IPerson person in GetPeopleAsync())
        {
            if (filter(person.EmailAddress))
            {
                yield return (person.FirstName, person.LastName);
            }
        }
    }

    public async Task<string> GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
    {
        HashSet<string> states = [];
        await foreach (IPerson person in people)
        {
            states.Add(person.Address.State);
        }

        return string.Join(", ", states.OrderBy(state => state));
    }
}