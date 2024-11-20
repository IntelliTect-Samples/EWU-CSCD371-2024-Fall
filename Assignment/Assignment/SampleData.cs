using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows => throw new NotImplementedException();

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();

        // 4.
        public IEnumerable<IPerson> People
        {
            get
            {
                IEnumerable<IPerson> peopleOut = new List<IPerson>();
                IEnumerable<string[]> peopleIn = CsvRows.Select(CsvRows => CsvRows.Split(','));
                foreach (string[] person in peopleIn) 
                {
                    string[] currentPerson = person;
                    peopleOut = peopleOut.Append(new Person(currentPerson[1], currentPerson[2], new Address(currentPerson[4], currentPerson[5], currentPerson[6], currentPerson[7]), currentPerson[3]));
                }
                peopleOut = peopleOut.OrderBy(p => p.Address.State).ThenBy(p => p.Address.City).ThenBy(p => p.Address.Zip);
                return peopleOut;
            }
        }

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            IEnumerable<IPerson> people = People.Where(p => filter(p.EmailAddress));
            return people.Select(p => (p.FirstName, p.LastName));
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
