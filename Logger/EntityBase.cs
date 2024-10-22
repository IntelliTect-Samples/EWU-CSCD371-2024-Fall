using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class EntityBase : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    //public EntityBase()
    //{
    //    Id = Guid.NewGuid();
    //}

    public abstract string Name { get; set; }
}

