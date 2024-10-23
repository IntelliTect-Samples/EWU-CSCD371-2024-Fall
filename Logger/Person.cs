

namespace Logger;

public abstract record class Person : Entity

{

    public Person(string first, string last, string id, string middle = "")
    {
        MyFullName = new FullName() { First = first,Last = last};
        Id = id;
    }
    public FullName MyFullName { get; set; } 
    public string Id { get; init; }
    protected override string ParseName()
    {
        return MyFullName.ToString();
    }

}
