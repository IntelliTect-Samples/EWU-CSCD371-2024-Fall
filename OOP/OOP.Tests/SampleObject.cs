namespace OOP.Tests;

public partial class UnitTest1
{
    public class SampleObject() : IPersist
    {
        public string GetData()
        {
            throw new NotImplementedException();
        }

        public object LoadData(string data)
        {
            throw new NotImplementedException();
        }
    }
}