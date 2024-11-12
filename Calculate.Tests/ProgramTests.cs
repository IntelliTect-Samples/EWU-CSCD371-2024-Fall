namespace Calculate.Tests
{
    public class ProgramTests
    {
        private string Output = "";
        private const string Input = "Testing";

        [Fact]
        public void Program_WriteLine_InvokesCorrectly()
        {
            // Arrange
            var program = new Program(
                writeLine: text => Output = text,
                readLine: () => Input
            );

            // Act
            program.WriteLine("Howdy");

            // Assert
            Assert.Equal("Howdy", Output);
        }

        [Fact]
        public void Program_ReadLine_InvokesCorrectly()
        {
            // Arrange
            var program = new Program(
                writeLine: text => Output = text,
                readLine: () => Input
            );

            // Act
            var readResult = program.ReadLine();

            // Assert
            Assert.Equal(Input, readResult);
        }
    }
}

