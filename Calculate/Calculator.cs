namespace Calculate;

public class Calculator
{

    public static int Add(int a, int b) => a + b;

    public static int Subtract(int a, int b) => a - b;

    public static int Multiple(int a, int b) => a * b;

    public static int Divide(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by 0");

    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiple,
        ['/'] = Divide
    };

    public bool TryCalculate(string expression, out int result)
    {
        result = int.MaxValue;
        var parts = expression.Split(' ');

        if (parts.Length != 3)
        {
            return false;
        }

        if (int.TryParse(parts[0], out int operands1) &&
            int.TryParse(parts[2], out int operands2) &&
            MathematicalOperations.TryGetValue(parts[1][0], out var operation))
        {
            try
            {
                result = operation(operands1, operands2);
                return true;
            }
            catch (DivideByZeroException)
            {
                return false;
            }
        }

        return false;
    }
}
