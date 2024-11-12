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
            var input = "3 + 4";
            var expectedOutput = "Enter a mathematical expression (e.g., 3 + 4):\nResult: 7\n";
            var stringReader = new StringReader(input);
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);

            // Act
            Program.Main();

            // Assert
            var output = stringWriter.ToString();
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Main_InvalidExpression_PrintsErrorMessage()
        {
            // Arrange
            var input = "invalid expression";
            var expectedOutput = "Enter a mathematical expression (e.g., 3 + 4):\nInvalid expression. Please enter a valid mathematical expression.\n";
            var stringReader = new StringReader(input);
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);

            // Act
            Program.Main();

            // Assert
            var output = stringWriter.ToString();
            Assert.Equal(expectedOutput, output);
        }
    }
    

