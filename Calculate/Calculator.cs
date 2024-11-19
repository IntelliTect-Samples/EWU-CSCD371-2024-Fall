namespace Calculate;

public class Calculator
{

    public static double Add(double a, double b) => a + b;
                  
    public static double Subtract(double a, double b) => a - b;
                  
    public static double Multiple(double a, double b) => a * b;
                
    public static double Divide(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by 0");

    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; } = new Dictionary<char, Func<double, double, double>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiple,
        ['/'] = Divide
    };

    public bool TryCalculate(string expression, out double result)
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
