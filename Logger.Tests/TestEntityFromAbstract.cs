
namespace Logger.Tests;

public record class TestEntityFromAbstract : Entity
{
    private FullName fullName;
    public TestEntityFromAbstract(string firstName,string lastName,string? middleName = null)
    {
        fullName = new() { First = firstName, Last = lastName, Middle = middleName };
    }
    protected override string ParseName()
    {
        return fullName.ToString();
    }
}
