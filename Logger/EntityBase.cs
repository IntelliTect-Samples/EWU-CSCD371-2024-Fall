using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; private set; }

    public EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public abstract string Name { get; init; }
}

