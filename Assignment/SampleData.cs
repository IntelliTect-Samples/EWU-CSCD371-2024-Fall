namespace Assignment;

public class SampleData : SampleDataBase, ISampleData
{
    public SampleData(string fileName) : base(fileName)
    {
        ValidateAndReadHeader(); // Ensure file and header are valid
    }

    public IEnumerable<string> CsvRows => File.ReadLines(FileName).Skip(1);

    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        return CsvRows
            .Select(row => CsvHelper.ParseRow(row)[6])
            .Distinct()
            .OrderBy(state => state);
    }

    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        return string.Join(", ", GetUniqueSortedListOfStatesGivenCsvRows());
    }

    public IEnumerable<IPerson> People => CsvRows
        .Select(row => CsvHelper.CreatePerson(CsvHelper.ParseRow(row)))
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
        return string.Join(", ", people
            .Select(person => person.Address.State)
            .Distinct()
            .OrderBy(state => state));
    }
}