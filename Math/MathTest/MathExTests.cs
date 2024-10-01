using MathExtensions;

namespace MathTest;

[TestClass]
public sealed class MathExTests
{
    [TestMethod]
    [DataRow(1, 2, 3)]
    [DataRow(2, 3, 5)]
    [DataRow(0, 1, 1)]
    [DataRow(-1, -2, -3)]
    [DataRow(0, -1, -1)]
    [DataRow(0, 0, 0)]
    [DataRow(int.MinValue, int.MaxValue, -1)]
    // MethodUnderTest_ConditionUnderTest_ExpectedResult
    public void Add_LeftAndRight_ReturnsExpected(int left, int right, int expected)
    {
        // Arrange
        // Act
        int result = MathEx.Add(left, right);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Add_OneAndFortyTwo_ReturnsFortyThree()
    {
        // Arrange
        int left = 1;
        int right = 42;
        // Act
        int result = MathEx.Add(left, right);
        // Assert
        Assert.AreEqual(43, result);
    }

    [TestMethod]
    public void Add_MinusOneAndMinusTwo_ReturnsMinusThree()
    {
        // Arrange
        int left = -1;
        int right = -2;
        // Act
        int result = MathEx.Add(left, right);
        // Assert
        Assert.AreEqual(-3, result);
    }
}
