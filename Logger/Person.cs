using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract record class Person(FullName NameDetails) : BaseEntity
    {
        public FullName LegalName { get; set; } = NameDetails;

        public override string Name => NameDetails.ToString();
    }
}
