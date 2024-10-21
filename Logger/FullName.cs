namespace Logger;

/*
   I've created FullName as a reference type because it represents a person's identity, 
   which can be conceptually shared or passed around without the need to copy the entire object. 
   Using a reference type allows the object to be passed between methods or components efficiently, 
   avoiding unnecessary memory duplication while maintaining immutability.
*/

/*
    The FullName record is immutable because all its properties are read-only and can only be set during 
    object initialization.This ensures that once a FullName object is created, its state cannot be modified.
*/

//credits: Programming C# 12: Build Cloud, Web, and Desktop Applications by Ian Griffiths
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