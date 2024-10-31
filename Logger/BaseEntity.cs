using System;
namespace Logger;

    public abstract record class BaseEntity : IEntity
    {
        
        public Guid Id { get; init; }
        protected BaseEntity()
        {
            //this.GuId = new Random().Next();
            Id = Guid.NewGuid();
        }
        public string Name => ParseName();
        public abstract string ParseName();

    }
