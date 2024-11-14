using System;
using System.Collections.Generic;
using System.Numerics;

namespace Calculate;

public class Calculator<T> where T : INumber<T>
{
    public static T Add(T a, T b) => a + b;
    public static T Subtract(T a, T b) => a - b;
    public static T Multiply(T a, T b) => a * b;
    public static T Divide(T a, T b)
    {
        if (b == T.Zero)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }

    public IReadOnlyDictionary<char, Func<T, T, T>> MathematicalOperations { get; } = new Dictionary<char, Func<T, T, T>>
    {
        ['+'] = (a, b) => a + b,
        ['-'] = (a, b) => a - b,
        ['*'] = (a, b) => a * b,
        ['/'] = (a, b) => b != T.Zero ? a / b : throw new DivideByZeroException()
    };

    public bool TryCalculate(string expression, out T? result)
    {
        string[] parts = expression.Split(' ');
        if (parts.Length != 3)
        {
            result = default;
            return false;
        }

        if (T.TryParse(parts[0], null, out T? operand1) &&
            T.TryParse(parts[2], null, out T? operand2) &&
            MathematicalOperations.ContainsKey(parts[1][0]))
        {
            try
            {
                char operationChar = parts[1][0];
                Func<T, T, T> operation = MathematicalOperations[operationChar];
                result = operation(operand1!, operand2!);
                return true;
            }
            catch (FormatException)
            {
                throw new FormatException("Unable to parse input.");
            }
        }

        result = default;
        return false;
    }
}
