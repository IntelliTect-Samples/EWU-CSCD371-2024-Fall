using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Student(FullName FullName) : BaseEntity
    {
        // calculated property, no backing 
        public override string Name => FullName.ToString();
    }
}
