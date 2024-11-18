using System.Globalization;
using System.Numerics;

namespace Calculate;
public class Calculator<T> where T : INumber<T>
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1859:Use concrete types for improved performance")]
    public IReadOnlyDictionary<char, Func<T, T, double>> MathematicalOperations { get; }

    public Calculator()
    {
        MathematicalOperations = new Dictionary<char, Func<T, T, double>>
        {
            { '+', (a, b) => { Add(a, b, out double result); return result; } },
            { '-', (a, b) => { Subtract(a, b, out double result); return result; } },
            { '*', (a, b) => { Multiply(a, b, out double result); return result; } },
            { '/', (a, b) =>
                {
                    if (b == T.Zero)
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

           if (!T.TryParse(firstOperand, out T? firstNumber) ||
!T.TryParse(secondOperand, out T?secondNumber))

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

    public void Add(T num1, T num2, out double result)
    {
        result = double.CreateChecked(num1 + num2);
    }

    public void Divide(T num1, T num2, out double result)
    {
        result = double.CreateChecked(num1 / num2);
    }

    public void Multiply(T num1, T num2, out double result)
    {
        result = double.CreateChecked(num1 * num2);
    }

    public void Subtract(T num1, T num2, out double result)
    {
        result = double.CreateChecked(num1 - num2);
    }
    

}
