
namespace Assignment;

public class SampleData : ISampleData
{

    public SampleData()
    {
        CsvRows = File.ReadAllLines("People.csv");
    }

    public SampleData(string filePath)
    {
        CsvRows = File.ReadAllLines(filePath);
    }


    public SampleData(IEnumerable<string> csvValues)
    {
        CsvRows = csvValues;
    }


    private IEnumerable<string>? _csvRows;
    // 1.
    public IEnumerable<string> CsvRows
    {
        get => _csvRows!;
        set => _csvRows = value.Skip(1) ?? [];
    }

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        throw new NotImplementedException();
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        throw new NotImplementedException();
    }

    // 4.
    public IEnumerable<IPerson> People => throw new NotImplementedException();

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter)
    {
        throw new NotImplementedException();
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
        throw new NotImplementedException();
    }
}
