namespace Logger
{
    public record class FullName()
    {
        
        public required string FirstName { get; set; } 
        public string? MiddleName { get; set; } = " ";
        public required string LastName { get; set; } 
        public override string ToString() => $"{FirstName}, {MiddleName?.Trim()}, {LastName}";
    }
}