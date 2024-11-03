namespace Calculate.Core;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, double>> Operations = new Dictionary<char, Func<int, int, double>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiply,
        ['/'] = Divide
    };

    public static double TryCalculate(int a, int b, Func<int, int, double> operation)
    {
        return 0;
    }
    public static double Add(int a, int b)
    {
        return a + b;
    }

    public static double Subtract(int a, int b)
    {
        return a - b;
    }

    public static double Multiply(int a, int b)
    {
        return a * b;
    }

    public static double Divide(int a, int b)
    {
        return a / b;
    }
}