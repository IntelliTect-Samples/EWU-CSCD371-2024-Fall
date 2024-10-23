using System;

namespace Logger
{
    public record Student(FullName FullName) : BaseEntity
    {
        // The Name property is implemented implicitly because the interface defines it,
        // and we dont need further customization. 
        public override string Name => FullName.ToString();

        // The Id property is inherited from BaseEntity, which implements it according to the IEntity interface.
    }
}
