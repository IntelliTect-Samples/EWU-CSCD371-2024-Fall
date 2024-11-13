namespace Calculate;

public class Calculator
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiplication(int a, int b) => a * b;
    public static int Division(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }

    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; } = new Dictionary<char, Func<int, int, int>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiplication,
        ['/'] = Division
    };

    public bool TryCalculate(string expression, out int? result)
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
                    Func<int, int, int> operation = MathematicalOperations[operationChar];
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
