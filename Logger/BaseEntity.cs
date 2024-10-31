using System;
namespace Logger;

    public abstract record class BaseEntity : IEntity
    {
     /*
            * Constructor for BaseEntity
            BaseEntity is a base class that is extended by Book and Student
            It implements the IEntity interface, and adds a Guid Id to the class.
            BaseEntity is Explicitly calling IEntity Interface 
     */   
        public Guid Id { get; init; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public string Name => ParseName();
        public abstract string ParseName();

    }
