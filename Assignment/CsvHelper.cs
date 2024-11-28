namespace Assignment;

public static class CsvHelper
{
    public const string ExpectedHeader = "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip";

    public static void ValidateHeader(string header)
    {
        if (header is null or not ExpectedHeader)
        {
            throw new FormatException($"Invalid header: {header}");
        }
    }

    public static Person CreatePerson(string[] columns)
    {
        Address address = new(columns[4], columns[5], columns[6], columns[7]);
        return new Person(columns[1], columns[2], address, columns[3]);
    }
}