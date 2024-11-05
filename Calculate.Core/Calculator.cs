namespace Calculate.Core;

public class Calculator
{
    private readonly Dictionary<char, Operation> _mathematicalOperations = new()
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiply,
        ['/'] = Divide
    };

    public IReadOnlyDictionary<char, Operation> MathematicalOperations => _mathematicalOperations;

    public bool TryCalculate(string calculation, out double result)
    {
        result = 0;

        string[]? parts = calculation.Split(' ');
        if (parts.Length != 3)
        {
            return false;
        }

        if (!int.TryParse(parts[0], out int operand1) || !int.TryParse(parts[2], out int operand2))
        {
            return false;
        }

        char operatorChar = parts[1][0];
        if (!_mathematicalOperations.TryGetValue(operatorChar, out Operation? operation))
        {
            return false;
        }

        return operation(operand1, operand2, out result);
    }

    public delegate bool Operation(int a, int b, out double result);

    public static bool Add(int a, int b, out double result)
    {
        result = a + b;
        return true;
    }

    public static bool Subtract(int a, int b, out double result)
    {
        result = a - b;
        return true;
    }

    public static bool Multiply(int a, int b, out double result)
    {
        result = a * b;
        return true;
    }

    public static bool Divide(int a, int b, out double result)
    {
        if (b == 0)
        {
            result = 0;
            return false;
        }
        result = a / (double)b;
        return true;
    }
}