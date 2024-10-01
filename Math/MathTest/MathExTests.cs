using MathExtension;

namespace MathTest
{
    [TestClass]
    public class MathExTests
    {
        [TestMethod]
        public void Add_OneAndTwo_ReturnsThree()
        {
            //Arange
            int left = 1;
            int right = 2;

            //Act
            int result = MathEx.Add(left, right);

            //Assert
            Assert.AreEqual(expected:3, result);

        }
        [TestMethod]
        public void Add_OneAndFortyTwo_ReturnsFortyThree()
        {
            //Arange
            int left = 1;
            int right = 42;

            //Act
            int result = MathEx.Add(left, right);

            //Assert
            Assert.AreEqual(expected: 43, result);
        }
    }
}