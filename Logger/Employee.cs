namespace Logger;

public record Employee(FullName FullName) : BaseEntity
{
    // The Name property is implemented implicitly because the IEntity interface defines it,
    // and we are overriding it with a calculated property (FullName.ToString()).
    public override string Name => FullName.ToString();

    // The Id property is inherited from BaseEntity, which implements with the IEntity interface.
    // We do not need to explicitly define it here because BaseEntity handles it.
}
