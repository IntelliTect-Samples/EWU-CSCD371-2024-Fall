using System;
using System.Collections.Generic;
namespace Calculate;

public class Calculator
{
    public static double Add(int a, int b) => a + b;
    public static double Subtract(int a, int b) => a - b;
    public static double Multiplication(int a, int b) => a * b;
    public static double Division(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return (double)a / b;
    }

    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, double>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiplication,
        ['/'] = Division
    };

    public bool TryCalculate(string expression, out double? result)
    {
        string[] parts = expression.Split(' ');
        if (parts.Length != 3)
        {
            result = null;
            return false;
        }
        else
        {
            if (int.TryParse(parts[0], out int opera1) && int.TryParse(parts[2], out int opera2) && MathematicalOperations.ContainsKey(parts[1][0]))
            {
                try
                {
                    char operationChar = parts[1][0];
                    Func<int, int, double> operation = MathematicalOperations[operationChar];
                    result = operation(opera1, opera2);
                    return true;
                }
                catch (FormatException)
                {
                    throw new FormatException("Unable to Parse");
                }


            }

        }
        result = null;
        return false;
    }
}
