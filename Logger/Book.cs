using System;

namespace Logger;

public record class Book : EntityBase
{
    public Book(string name)
    {
        Name = name;
    }

    public override string Name { get; }
}
