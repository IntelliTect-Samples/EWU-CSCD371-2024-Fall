using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class EntityBase : IEntity
{
    private readonly Guid _guid = Guid.NewGuid();

    Guid IEntity.Id
    {
        get => _guid;
    }

    public abstract string Name { get; }
}

