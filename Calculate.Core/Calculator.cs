namespace Calculate.Core;

public static class Calculator
{

    public static int TryCalculate(int a, int b, Func<int, int, double> operation)
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