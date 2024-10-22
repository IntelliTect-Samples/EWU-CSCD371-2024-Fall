namespace Logger;

public record Student(FullName nameDetails) : EntityBase
{
    // TODO: Figure out if these should be set or init or read only
    public override string Name
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(nameDetails.MiddleName))
            {
                return $"{nameDetails.FirstName} {nameDetails.MiddleName} {nameDetails.LastName}";
            }
            return $"{nameDetails.FirstName} {nameDetails.LastName}";
        }
    }
}