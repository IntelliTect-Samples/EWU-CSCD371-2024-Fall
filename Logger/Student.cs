namespace Logger;

public record class Student(FullName NameDetails) : Person(NameDetails)
{
    // TODO: Figure out if these should be set or init or read only
    //public FullName NameDetails { get; set; } = NameDetails;
    //public override string Name
    //{
    //    get
    //    {
    //        if (!string.IsNullOrWhiteSpace(NameDetails.MiddleName))
    //        {
    //            return $"{NameDetails.FirstName} {NameDetails.MiddleName} {NameDetails.LastName}";
    //        }
    //        return $"{NameDetails.FirstName} {NameDetails.LastName}";
    //    }
    //}
}