

namespace Assignment;

public class SampleDataAsync : IAsyncSampleData
{
    //1
    IAsyncEnumerable<string> IAsyncSampleData.CsvRows => throw new NotImplementedException();

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
