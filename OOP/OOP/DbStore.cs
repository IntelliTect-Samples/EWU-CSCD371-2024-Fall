
namespace OOP
{
    public class DbStore : IStorage
    {
        public string GetData()
        {
            throw new NotImplementedException();
        }

        public IPersist Load(string data)
        {
            throw new NotImplementedException();
        }

        public object LoadData(string data)
        {
            throw new NotImplementedException();
        }

        public object LoadObject(string data)
        {
            throw new NotImplementedException();
        }

        public string Save(IPersist obj)
        {
            string data = obj.GetData();
            // Save data to database
            return data;
        }

        void IStorage.Save(IPersist persist)
        {
            throw new NotImplementedException();
        }
    }
}