namespace Logger;

/*
 Instructions: 
    Define an abstract base class that implements IEntity - appropriately choosing to implement the interface explicitly or implicitly. ✔
    Do not implement the Name property in this abstract class. ✔
    Do force any derived classes to provide an implementation for Name. ✔
 */
public abstract record EntityBase : IEntity
{
   
    /// Explicit implementation of IEntity.Id.
    Guid IEntity.Id { get; } = Guid.NewGuid();
    public abstract string Name { get; }
    
}

