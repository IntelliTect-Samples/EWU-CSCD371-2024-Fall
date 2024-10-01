using MathExtensions;

namespace MathTest;

[TestClass]
public sealed class MathExTests
{
    [TestMethod]
    // MethodUnderTest_ConditionUnderTest_ExpectedResult
    public void Add_OneAndTwo_ReturnsThree()
    {
        // Arrange
        int left = 1;
        int right = 2;
        // Act
        int result = MathEx.Add(left, right);

        // Assert
        Assert.AreEqual(3, result);
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
}
