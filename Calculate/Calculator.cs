using System;
using System.Collections.Generic;

public class Calculator
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static int Divide(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException("Can't divide by zero!");

    public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } =
        new Dictionary<char, Func<int, int, int>>
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiply },
            { '/', Divide }
        };

    public static bool TryCalculate(string input, out int result)
    {
        result = 0;
        var parts = input.Split(' ');

        if (parts.Length != 3)
            return false;

        if (int.TryParse(parts[0], out int operand1) &&
            int.TryParse(parts[2], out int operand2) &&
            parts[1].Length == 1 &&
            MathematicalOperations.TryGetValue(parts[1][0], out var operation))
        {
            try
            {
                result = operation(operand1, operand2);
                return true;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
                return false;
            }
        }

        return false;
    }
}

