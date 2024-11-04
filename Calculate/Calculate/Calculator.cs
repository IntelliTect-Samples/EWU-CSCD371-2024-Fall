namespace Calculate;

public class Calculator
{
    public static void Add(int num1, int num2, out int result) => result = num1 + num2;

    public static void Subtract(int num1, int num2, out int result) => result = num1 - num2;

    public static void Multiply(int num1, int num2, out int result) => result = num1 * num2;

    public static void Divide(int num1, int num2, out double result)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException();
        }
        result = (double)num1 / num2;
    }
}