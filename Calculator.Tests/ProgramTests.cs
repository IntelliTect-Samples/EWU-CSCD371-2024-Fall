using System;
using Xunit;
using Moq;
using Calculator;
namespace Calculator.Tests;
public class ProgramTest
{
    [Fact]
    public void Main_ValidExpression_PrintsResult()
    {
        // Arrange
        var mockWriteLine = new Mock<Action<string>>();
        var mockReadLine = new Mock<Func<string?>>();
        mockReadLine.Setup(r => r()).Returns("3 + 4");

        var program = new Program(mockWriteLine.Object, mockReadLine.Object);

        // Act
        program.Main();

        // Assert
        mockWriteLine.Verify(w => w("Enter a mathematical expression (e.g., 3 + 4):"), Times.Once);
        mockWriteLine.Verify(w => w("Result: 7"), Times.Once);
    }

    [Fact]
    public void Main_InvalidExpression_PrintsErrorMessage()
    {
        // Arrange
        var mockWriteLine = new Mock<Action<string>>();
        var mockReadLine = new Mock<Func<string?>>();
        mockReadLine.Setup(r => r()).Returns("invalid");

        var program = new Program(mockWriteLine.Object, mockReadLine.Object);

        // Act
        program.Main();

        // Assert
        mockWriteLine.Verify(w => w("Enter a mathematical expression (e.g., 3 + 4):"), Times.Once);
        mockWriteLine.Verify(w => w("Invalid expression. Please enter a valid mathematical expression."), Times.Once);
    }
}
