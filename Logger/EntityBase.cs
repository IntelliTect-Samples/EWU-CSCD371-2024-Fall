using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class EntityBase : IEntity
{
    private readonly Guid _guid = Guid.NewGuid();

    // The Guid is explicitly implemented to ensure that the Id property 
    // is only accessible through the IEntity interface.
    // This allows for better control on how the Id is exposed.
    // The reason we did this is because we did not think the Guid was going to 
    // be used on a regular basis. A student/emplyee will have a student/employee Id number
    // and a book will have a ISBN or some other identifier, so we did not want to expose the Guid.
    Guid IEntity.Id
    {
        get => _guid;
    }

    public abstract string Name { get; }
}

