namespace Assignment;

public interface IAsyncSampleData
{
    // 1.
    IAsyncEnumerable<string> GetCsvRowsAsync();

    // 2.
    IAsyncEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows();

    // 3.
    Task<string> GetAggregateSortedListOfStatesUsingCsvRows();

    // 4.
    IAsyncEnumerable<IPerson> GetPeopleAsync();

    // 5.
    IAsyncEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter);

    // 6.
    Task<string> GetAggregateListOfStatesGivenPeopleCollection(IAsyncEnumerable<IPerson> people);
}