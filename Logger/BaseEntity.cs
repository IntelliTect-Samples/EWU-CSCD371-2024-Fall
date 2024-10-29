namespace Logger;

    public abstract record class BaseEntity : IEntity
    {
        public abstract string Name { get;}
        public Guid id { get; init; }
        protected BaseEntity()
        {
            //this.GuId = new Random().Next();
            Guid id = Guid.NewGuid();
        }
    }
