using System;
namespace Logger;
public interface IEntity
{
        /*
                IEntity is explicitly defined as an interface to be implemented by BaseEntity
                and any other class that needs to be stored in the Storage class.
        */
        Guid Id { get;}
        string Name { get; }
        string ParseName();
}
