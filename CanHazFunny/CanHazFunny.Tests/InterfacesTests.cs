using CanHazFunny;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanHazFunny.Tests
{

    [TestClass]
    public class InterfacesTests
    {
        [TestMethod]
        public void JokerService_HasJsInterface_ReturnTrue()
        {
            // 1.Arrange
            var type = typeof(JokeService);

            // 2.Act
            bool hasInterface = typeof(IJokeService).IsAssignableFrom(type);

            //3. Assess
            Assert.AreEqual(true, hasInterface);
        }
    }
}