namespace Calculate.Core;

public class Calculator
{
    private readonly Dictionary<char, Func<int, int, double>> _mathematicalOperations;

    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations => _mathematicalOperations;

    public Calculator()
    {
        _mathematicalOperations = new Dictionary<char, Func<int, int, double>>
        {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide
        };
    }

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
        if (!_mathematicalOperations.TryGetValue(operatorChar, out Func<int, int, double>? operation))
        {
            return false;
        }

        result = operation(operand1, operand2);
        return true;
    }

    public static double Add(int a, int b) => a + b;

    public static double Subtract(int a, int b) => a - b;

    public static double Multiply(int a, int b) => a * b;

    public static double Divide(int a, int b) => b != 0 ? a / (double)b : throw new DivideByZeroException();
}