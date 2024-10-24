namespace Logger;

public record class Book(string Title) : BaseEntity
{
    // The Name property is implemented implicitly because the IEntity interface defines it,
    // and we override it by returning the books Title.
    public override string Name => Title;

    // The Id property is inherited from BaseEntity, which implements it with the IEntity interface.
    // We do not need to explicitly define it here because BaseEntity handles it.
}
