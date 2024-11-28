namespace Assignment;

public class SampleData : SampleDataBase, ISampleData
{
    public SampleData(string fileName) : base(fileName)
    {
        ValidateAndReadHeader();
    }

    public IEnumerable<string> CsvRows => File.ReadLines(FileName).Skip(1);

    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(row => row.Split(',')[6])
            .Distinct()
            .OrderBy(state => state);
    }

    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        return GetUniqueSortedListOfStatesGivenCsvRows()
            .Aggregate((current, next) => current + ", " + next);
    }

    public IEnumerable<IPerson> People => CsvRows
        .Select(row => CsvHelper.CreatePerson(row.Split(',')))
        .OrderBy(person => person.Address.State)
        .ThenBy(person => person.Address.City)
        .ThenBy(person => person.Address.Zip);

    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        return People
            .Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));
    }

    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
    {
        if (people is null || !people.Any())
        {
            return string.Empty;
        }

        IOrderedEnumerable<string> uniqueStates = people.Select(person => person.Address.State)
                                  .Distinct()
                                  .OrderBy(state => state);

        string result = uniqueStates.Aggregate((current, next) => current + ", " + next);

        IEnumerable<string> expectedStates = GetUniqueSortedListOfStatesGivenCsvRows();
        return !result.Equals(string.Join(", ", expectedStates), StringComparison.Ordinal)
               ? throw new InvalidOperationException("Validation failed: Result does not match the expected unique sorted list of states.")
               : result;
    }
}