using System.Linq;
namespace Assignment;


public class SampleDataAsync : IAsyncSampleData
{

    // 1.
    private IAsyncEnumerable<string>? _csvRows;

    public IAsyncEnumerable<string> CsvRows
    {
        get => _csvRows!;
        set => _csvRows = value?.Skip(1) ?? AsyncEnumerable.Empty<string>();
    }

    //We want to load the file async on construction
    public SampleDataAsync()
    {
        CsvRows = File.ReadLinesAsync("People.csv");
    }


    //2
    public IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state);
    }

    //3
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        IAsyncEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();

        //Local function to do async work
        async Task<string> GetAggregate()
        {
            return await states.AggregateAsync((old, newval) => $"{old}, {newval}");
        }

        return GetAggregate().Result;
    }

    //4
    public IAsyncEnumerable<IPerson> People =>
        CsvRows.Select(row =>
        {
            string[] values = row.Split(',');
            return new Person(values[1], values[2],
                new Address(values[4], values[5], values[6], values[7]), values[3]);
        }).
        OrderBy(person => person.Address.State).
        ThenBy(person => person.Address.City).
        ThenBy(person => person.Address.Zip);

    //5
    public IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        IAsyncEnumerable<(string FirstName, string LastName)> result;
        result = People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));

        return result;
    }
    //6
    public string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
    {
        throw new NotImplementedException();
    }

}
