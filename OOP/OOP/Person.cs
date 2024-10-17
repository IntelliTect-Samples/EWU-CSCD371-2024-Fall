namespace OOP;

public class Person : IPersist
{
    string IPersist.GetData()
    {
        throw new NotImplementedException();
    }

    object IPersist.LoadData(string data)
    {
        throw new NotImplementedException();
    }
}
