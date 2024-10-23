using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Book(string Title) : BaseEntity
    {
        //No backing field
        public override string Name => Title;
    }
}
