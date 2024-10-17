namespace OOP;

public interface IStorage
{
    void Save(IPersist persist);
    IPersist Load(string data);
    T LoadObject<T>(string data) where T : IPersist
    {
        return (T)Load(data);
    }
}