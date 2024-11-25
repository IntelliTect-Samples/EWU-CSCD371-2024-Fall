using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // 1.
        public IEnumerable<string> CsvRows { get; } = from line in File.ReadAllLines("People.csv")
                                                      where !line.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip")
                                                      select line;

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {

            IEnumerable<string> peopleIn = from row in CsvRows.Select(row => row.Split(','))
                                                     select row[6];

            return (from pe in peopleIn
                   orderby pe
                   select pe).Distinct();
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> uniqueStates = GetUniqueSortedListOfStatesGivenCsvRows();
            return string.Join(",", uniqueStates);
        }

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
                peopleOut.OrderBy(p => p.Address.State).ThenBy(p => p.Address.City).ThenBy(p => p.Address.Zip);
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
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            IEnumerable<string> uniqueSort = people.Select(p => p.Address.State).Distinct().OrderBy(state => state);
            return uniqueSort.Aggregate((current, next) => current + ", " + next);
        }
    }
}
