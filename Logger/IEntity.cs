using System;
namespace Logger;
public interface IEntity
{
        Guid Id { get;}
        string Name { get; }
        string ParseName();
}
