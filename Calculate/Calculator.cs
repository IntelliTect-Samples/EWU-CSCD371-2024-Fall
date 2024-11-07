namespace Calculate;

public class Calculator 
{

    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; }

    public Calculator()
    {
        MathematicalOperations = new Dictionary<char, Func<int, int, double>>
            {
                { '+', (a, b) => { Add(a, b, out double result); return result; } },
                { '-', (a, b) => { Subtract(a, b, out double result); return result; } },
                { '*', (a, b) => { Multiply(a, b, out double result); return result; } },
                { '/', (a, b) =>
                    {
                        if (b == 0)
                        {
                            throw new DivideByZeroException("Cannot divide by zero.");
                        }
                        Divide(a, b, out double result);
                        return result;
                    }
                }
            };
    }

    public bool TryCalculate(string input, out double result)
    {
        while (true)
        {
            string[] inputArray = input.Split(' ');
            if (inputArray.Length != 3)
            {
                result = 0;
                return false;
            }

            string firstOperand = inputArray[0];
            string operatorStr = inputArray[1];
            string secondOperand = inputArray[2];

            if (!char.TryParse(operatorStr, out char operatorChar) || !MathematicalOperations.ContainsKey(operatorChar))
            {
                result = 0;
                return false;
            }

            if (!int.TryParse(firstOperand, out int firstNumber) || !int.TryParse(secondOperand, out int secondNumber))
            {
                result = 0;
                return false;
            }

            try
            {
                result = MathematicalOperations[operatorChar](firstNumber, secondNumber);
                return true;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero. Please enter a new calculation:");
                input = Console.ReadLine()!;
            }
        }
    }

    public static void Add(int num1, int num2, out double result)
    {
        result = num1 + num2;
    }

    public static void Divide(int num1, int num2, out double result)
    {
        result = (double)num1/num2;
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