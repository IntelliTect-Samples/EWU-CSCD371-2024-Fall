namespace Assignment;

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

        // Collect all states into the HashSet
        await foreach (string row in GetCsvRowsAsync())
        {
            string state = CsvHelper.ParseRow(row)[6];
            states.Add(state);
        }

        // Sort the states alphabetically and yield them
        foreach (string state in states.OrderBy(s => s))
        {
            yield return state;
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
        List<IPerson> people = [];

        // Collect all rows and create Person objects
        await foreach (string row in GetCsvRowsAsync())
        {
            string[] columns = CsvHelper.ParseRow(row);
            Address address = new(columns[4], columns[5], columns[6], columns[7]);
            people.Add(new Person(columns[1], columns[2], address, columns[3]));
        }

        // Sort the list by State, City, and Zip
        IOrderedEnumerable<IPerson> sortedPeople = people
            .OrderBy(person => person.Address.State)
            .ThenBy(person => person.Address.City)
            .ThenBy(person => person.Address.Zip);

        // Yield the sorted list
        foreach (IPerson person in sortedPeople)
        {
            yield return person;
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