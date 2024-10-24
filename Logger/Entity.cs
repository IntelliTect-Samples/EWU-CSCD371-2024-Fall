using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract class Entity : IEntity
{
    // Explicit implementation
    Guid IEntity.Id { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

    // Implicit implementation
    public abstract string Name { get; }
}
