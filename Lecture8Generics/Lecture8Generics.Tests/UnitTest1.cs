using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lecture8Generics.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor()
        {
            Dictionary<int, string> dictionary = new();
            Assert.IsNotNull(dictionary);
        }

        [TestMethod]
        public void Add()
        {
            Dictionary<int, string> dictionary = GetTestDictionary();

            Assert.AreEqual("Inigo Montoya", dictionary.Get(42));
        }


        [TestMethod]
        public void Exists()
        {
            Dictionary<int, string> dictionary = GetTestDictionary();

            Assert.IsTrue(dictionary.KeyExists(42));
        }
        private static Dictionary<int, string> GetTestDictionary()
        {
            Dictionary<int, string> dictionary = new();
            dictionary.Add(41, "Six fingered man");
            dictionary.Add(42, "Inigo Montoya");
            dictionary.Add(43, "Princess Buttercup");
            return dictionary;
        }

    }
}