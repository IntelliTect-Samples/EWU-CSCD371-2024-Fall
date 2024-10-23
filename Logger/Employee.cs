using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public record Employee : Person
{

    public Employee(FullName name, string email,
        string phoneNumber, string companyName, string Position)
        : base(Guid.NewGuid(), name, email, phoneNumber)
    {

    }

}
