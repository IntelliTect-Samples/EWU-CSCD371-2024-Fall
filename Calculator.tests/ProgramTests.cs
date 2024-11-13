using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculate.tests
{
    public class ProgramTests
    {

        [Fact]
        public void Main_ValidEquation_PrintResult() 
        {
            
            // Arrange
            var input = "8 + 2";
            var expected = "Enter an arithmetic Operation to calculate (Ex, 4 + 3) : \r\nSolution : 10\r\n";

            var consoleReader = new StringReader(input);                
            var consoleWriter = new StringWriter();
            
            Console.SetIn(consoleReader);
            Console.SetOut(consoleWriter);

            // Act
            Program.Main();

            // Assert
            var actual = consoleWriter.ToString();
            Assert.Equal(expected, actual);
            
        }
    }
}
