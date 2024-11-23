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

    //1
    //We want to load the file async on construction
    public SampleDataAsync()
    {
        CsvRows = File.ReadLinesAsync("People.csv");
    }

    //2
    IAsyncEnumerable<IPerson> IAsyncSampleData.People => throw new NotImplementedException();

    //3
    public string GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people)
    {
        throw new NotImplementedException();
    }
    //4
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        throw new NotImplementedException();
    }
    //5
    IAsyncEnumerable<(string FirstName, string LastName)> IAsyncSampleData.FilterByEmailAddress(Predicate<string> filter)
    {
        throw new NotImplementedException();
    }
    //6
    IAsyncEnumerable<string> IAsyncSampleData.GetUniqueSortedListOfStatesGivenCsvRows()
    {
        throw new NotImplementedException();
    }
}
