namespace Logger;

public record Student(FullName nameDetails) : EntityBase
{
    public override string Name => nameDetails.ToString();

}