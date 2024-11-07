namespace Calculate;

public class Calculator 
{
    //private readonly Dictionary<string, Func<int, int, double>> _mathematicalOperations = new()
    //{
    //    { "+", (a, b) => a + b },
    //    { "-", (a, b) => a - b },
    //    { "*", (a, b) => a * b },
    //    { "/", (a, b) => b  != 0 ? a / b : throw new DivideByZeroException() }
    //};

    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; }

    public Calculator()
    {
        MathematicalOperations = new Dictionary<char, Func<int, int, double>>
            {
                { '+', (a, b) => { Add(a, b, out double result); return result; } },
                { '-', (a, b) => { Subtract(a, b, out double result); return result; } },
                { '*', (a, b) => { Multiply(a, b, out double result); return result; } },
                { '/', (a, b) => { Divide(a, b, out double result); return result; }
                }
            };
    }

    public bool TryCalculate(string input, out double result)
    {
        string[] inputArray = input.Split(' ');
        if (inputArray.Length != 3)
        {
            result = 0;
            return false;
        }
        string firstOpperand = inputArray[0];
        string opperatorStr = inputArray[1];
        string secondOpperand = inputArray[2];


        char opperator = opperatorStr[0];

        if (!int.TryParse(firstOpperand, out int firstNumber) || !int.TryParse(secondOpperand, out int secondNumber))
       {
           result = 0;
           return false;
       }
       
       result = MathematicalOperations[opperator](firstNumber, secondNumber);
       return true;
    }

    public static void Add(int num1, int num2, out double result)
    {
        result = num1 + num2;
    }

    public static void Divide(int num1, int num2, out double result)
    {
        result = num1/num2;
    }

    public static void Multiply(int num1, int num2, out double result)
    {
        result = num1 * num2;
    }

    public static void Subtract(int num1, int num2, out double result)
    {
        result = num1 - num2;
    }
}