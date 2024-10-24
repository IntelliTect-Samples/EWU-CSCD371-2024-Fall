using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class BaseEntity : IEntity
{
    // Every entity has an Id
    public Guid Id { get; init; } = Guid.NewGuid();

    // Each entity decides how to use Name
    public abstract string Name { get; set; }
}
