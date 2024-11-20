namespace Assignment;

public class SampleData : ISampleData
{
    private readonly string _fileName;

    private const string ExpectedHeader = "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip";

    public SampleData(string fileName)
    {
        _fileName = fileName;
        if (!File.Exists(_fileName))
        {
            throw new FileNotFoundException($"File not found: {_fileName}");
        }

        string? header = File.ReadLines(_fileName).FirstOrDefault();
        if (header is null or not ExpectedHeader)
        {
            throw new FormatException($"Invalid header: {header}");
        }
    }

    // 1.
    public IEnumerable<string> CsvRows
    {
        get
        {
            IEnumerable<string> data = File.ReadLines(_fileName);
            return data.Skip(1);
        }
    }

    // Note on IDisposable: File.ReadLines() does not require manual disposal of resources.
    // It internally manages the file stream and cleans it up automatically when the enumeration is complete.

    // 2.
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        IEnumerable<string> states = CsvRows.Select(row => row.Split(',')[6]).Distinct();
        return states.OrderBy(state => state);
    }

    // 3.
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        IEnumerable<string> rowOfStates = GetUniqueSortedListOfStatesGivenCsvRows();
        return string.Join(", ", rowOfStates);
    }

    // 4.
    public IEnumerable<IPerson> People
    {
        get
        {
            IEnumerable<Person> person = CsvRows.OrderBy
                (row => row.Split(',')[6])
                .ThenBy(row => row.Split(',')[5])
                .ThenBy(row => row.Split(',')[7])
                .Select(item =>
                {
                    string[] columns = item.Split(',');
                    Address address = new(columns[4], columns[5], columns[6], columns[7]);
                    return new Person(columns[1], columns[2], address, columns[3]);
                });

            return person;
        }
    }

    // 5.
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        return People
        .Where(person => filter(person.EmailAddress))
        .Select(person => (person.FirstName, person.LastName));
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
    {
        if (people == null || !people.Any())
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