﻿using System;
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
            Program program = new Program();
            var mockWriteLine = new Mock<Action<string>>();
            var mockReadLine = new Mock<Func<string?>>();
            mockReadLine.Setup(r => r()).Returns("3 + 4");

            program.WriteLine = mockWriteLine.Object;
            program.ReadLine = mockReadLine.Object;

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
            Program program = new Program();
            var mockWriteLine = new Mock<Action<string>>();
            var mockReadLine = new Mock<Func<string?>>();
            mockReadLine.Setup(r => r()).Returns("invalid");

            program.WriteLine = mockWriteLine.Object;
            program.ReadLine = mockReadLine.Object;

            // Act
            program.Main();

            // Assert
            mockWriteLine.Verify(w => w("Enter a mathematical expression (e.g., 3 + 4):"), Times.Once);
            mockWriteLine.Verify(w => w("Invalid expression. Please enter a valid mathematical expression."), Times.Once);
        }
    }
