namespace OOP;

public interface IPersist
{
    string GetData();
    object LoadData(string data);
}