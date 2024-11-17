
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

    // 4.
    public IEnumerable<IPerson> People => throw new NotImplementedException();

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows.Select(row => row.Split(',')[6]).Distinct().OrderBy(state => state);
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows();

        return states.Aggregate((accumlateList, states) =>
        $"{accumlateList}, {states}"); ;
    }
    //TODO: Ask about readme about ToArray()
    //TODO: Ask about string.Join()

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
