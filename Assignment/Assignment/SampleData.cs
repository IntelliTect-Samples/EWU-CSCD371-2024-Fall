
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
    public IEnumerable<IPerson> People =>
        CsvRows.Select(row =>
         {
             string[] values = row.Split(',');
             return new Person(values[1], values[2],
                 new Address(values[4], values[5], values[6], values[7]), values[3]);
         }).
        OrderBy(person => person.Address.State).
        ThenBy(person => person.Address.City).
        ThenBy(person => person.Address.Zip);

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
        List<(string first, string last)> resultEnumerable = [];
        foreach (Person person in People)
        {
            if (filter(person.EmailAddress))
            {
                resultEnumerable.Add((person.FirstName, person.LastName));

            }
        }

        return resultEnumerable;
    }

    // 6.
    public string GetAggregateListOfStatesGivenPeopleCollection(
        IEnumerable<IPerson> people)
    {
        return people.Select(people => people.Address.State).Distinct().OrderBy(state => state).Aggregate((oldStates, newState) => $"{oldStates}, {newState}");

    }
}
