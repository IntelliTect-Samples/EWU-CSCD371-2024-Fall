using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Employee : Person
    {
        private string? _position;
        private string? _department;
        private string? _company;

        public Employee(FullName legalName, string position, string department, string company) : base(legalName)
        {
            LegalName = legalName;
            Position = position;
            Department = department;
            Company = company;
        }

        public string Position
        {
            get => _position!;
            set 
            { 
                ArgumentNullException.ThrowIfNull(value, "Position cannot be null");
                _position = value;
            }
        }

        public string Department
        {
            get => _department!;
            set
            {
                ArgumentNullException.ThrowIfNull(value, "Department cannot be null");
                _department = value;
            }
        }

        public string Company
        {
            get => _company!;
            set
            {
                ArgumentNullException.ThrowIfNull(value, "Company cannot be null");
                _company = value;
            }
        }

    }
}
