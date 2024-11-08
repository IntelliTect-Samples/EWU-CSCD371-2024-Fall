using System.Globalization;

namespace Calculate.Core;

public class Calculator<T> where T : struct, IConvertible
{
    private readonly Dictionary<char, Operation> _mathematicalOperations;

    public IReadOnlyDictionary<char, Operation> MathematicalOperations => _mathematicalOperations;

    public delegate bool Operation(T a, T b, out double result);

    public Calculator()
    {
        _mathematicalOperations = new Dictionary<char, Operation>();
        {
            _mathematicalOperations.Add('+', Add);
            _mathematicalOperations.Add('-', Subtract);
            _mathematicalOperations.Add('*', Multiply);
            _mathematicalOperations.Add('/', Divide);
        }
    }

    public bool TryCalculate(string calculation, out double result)
    {
        result = 0;

        string[]? parts = calculation.Split(' ');
        if (parts.Length != 3)
        {
            return false;
        }

        if (!TryParse(parts[0], out T operand1) || !TryParse(parts[2], out T operand2))
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

    private static double ConvertToDouble(T value)
    {
        return Convert.ToDouble(value, CultureInfo.InvariantCulture);
    }

    public bool Add(T a, T b, out double result)
    {
        result = ConvertToDouble(a) + ConvertToDouble(b);
        return true;
    }

    public bool Subtract(T a, T b, out double result)
    {
        result = ConvertToDouble(a) - ConvertToDouble(b);
        return true;
    }

    public bool Multiply(T a, T b, out double result)
    {
        result = ConvertToDouble(a) * ConvertToDouble(b);
        return true;
    }

    public bool Divide(T a, T b, out double result)
    {
        if (ConvertToDouble(b) == 0)
        {
            result = 0;
            return false;
        }
        result = ConvertToDouble(a) / ConvertToDouble(b);
        return true;
    }

    private static bool TryParse(string input, out T result)
    {
        try
        {
            result = (T)Convert.ChangeType(input, typeof(T), CultureInfo.InvariantCulture);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
}