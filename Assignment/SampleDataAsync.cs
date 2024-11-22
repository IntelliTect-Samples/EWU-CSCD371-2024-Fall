namespace Assignment;

public class SampleDataAsync : SampleDataBase, IAsyncSampleData
{
    public SampleDataAsync(string fileName) : base(fileName)
    {
        ValidateAndReadHeader(); // Ensure file and header are valid
    }

    public async IAsyncEnumerable<string> CsvRows
    {
        get
        {
            using var reader = new StreamReader(FileName);
            string header = await reader.ReadLineAsync();
            CsvHelper.ValidateHeader(header);

            while (!reader.EndOfStream)
            {
                yield return await reader.ReadLineAsync();
            }
        }
    }

    public async IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        HashSet<string> states = [];
        await foreach (string row in CsvRows)
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

    public async IAsyncEnumerable<IPerson> People
    {
        get
        {
            await foreach (var row in CsvRows)
            {
                var person = CsvHelper.CreatePerson(CsvHelper.ParseRow(row));
                yield return person;
            }
        }
    }

    public async IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        await foreach (IPerson person in People)
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