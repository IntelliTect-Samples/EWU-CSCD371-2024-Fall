namespace Logger;

public record FullName(string FirstName, string? MiddleName, string LastName)
{
    
    /*
        w/out this override I get the following error for all properties:
        Positional property 'Logger.FullName.[propertyName]' 
        is never accessed (except in implicit Equals/ToString implementations)
     */
    public override string ToString()
    {
        if(MiddleName is null)
        {
            return $"{FirstName} {LastName}";
        }
        else
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}