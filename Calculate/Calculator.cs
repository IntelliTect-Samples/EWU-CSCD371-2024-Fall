
namespace Calculate;

public class Calculator 
{
    private readonly Dictionary<string, Func<int, int, double>> _mathematicalOperations = new()
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => a - b },
        { "*", (a, b) => a * b },
        { "/", (a, b) => b  != 0 ? a / b : throw new DivideByZeroException() }
    };
    
    public bool TryCalculate(string input, out double result)
    {
        string[] inputArray = input.Split(' ');
        if (inputArray.Length != 3)
        {
            result = 0;
            return false;
        }
        string firstOpperand = inputArray[0];
        string opperator = inputArray[1];
        string secondOpperand = inputArray[2];
         
       if(!int.TryParse(firstOpperand, out int firstNumber) || !int.TryParse(secondOpperand, out int secondNumber))
       {
           result = 0;
           return false;
       }
       
       result = _mathematicalOperations[opperator](firstNumber, secondNumber);
       return true;
    }

}