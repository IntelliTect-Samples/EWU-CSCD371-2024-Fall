using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

record struct FullName
{
    // Why we chose struct/class
    // Why we chose immutable/mutable

    string first;
    string? middle; // Optional
    string? last;   // Optional

    public string First { get => first; set => first = value; }
    public string? Middle { get => middle;
        set
        {
            // Handle optional/Null
            // Watch out for infinite loop
        }
    }

    public string? Last { get => last;
        set
        {
            // Handle optional/Null value 
            // Watch out for infinite loop
            // Set the value
        }
    }
}
