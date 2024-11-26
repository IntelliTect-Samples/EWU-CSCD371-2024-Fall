﻿using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class Person : IPerson
    {
        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            EmailAddress = emailAddress;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get;set; }
        public string EmailAddress { get; set; }
    }
}
