namespace Assignment;

public class SampleData : ISampleData
{
    // 1.
    public IEnumerable<string> CsvRows
    {
        get
        {
            IEnumerable<string> data = File.ReadLines("People.csv");
            return data.Skip(1);
        }
    }

    // Note on IDisposable: File.ReadLines() does not require manuel disposal of resources.
    // It internally manages the file stream and cleans it up automatically when the enumeration is complete.

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        IEnumerable<string> states = CsvRows.Select(row => row.Split(',')[6]).Distinct();
        return states.OrderBy(state => state);
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
        => throw new NotImplementedException();

    // 4.
    public IEnumerable<IPerson> People => throw new NotImplementedException();

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
        Predicate<string> filter) => throw new NotImplementedException();

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people) => throw new NotImplementedException();
}