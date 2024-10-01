using MathExtension;

namespace MathTest
{
    [TestClass]
    public class MathExTests
    {
        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(2, 3, 5)]
        [DataRow(3, 4, 7)]
        [DataRow(0, 1, 1)]
        public void Add_LeftAndRight_ReturnsExpected(int left, int right, int expected)
        {
            //Arange
            //int left = 1;
            //int right = 2;

            //Act
            int result = MathEx.Add(left, right);

            //Assert
            Assert.AreEqual(expected, result);

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