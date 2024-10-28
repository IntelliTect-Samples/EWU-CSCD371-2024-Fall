using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Employee (FullName FullName) : Entity
{
    public override string Name => FullName.ToString();
}
