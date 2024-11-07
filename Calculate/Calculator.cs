namespace Calculate;

public class Calculator
{
    public static void Add(int num1, int num2, out double result)
    {
        result = num1 + num2;
    }

    public static void Divide(int num1, int num2, out double result)
    {
        result = num1/num2;
    }

    public static void Multiply(int num1, int num2, out double result)
    {
        result = num1 * num2;
    }

    public static void Subtract(int num1, int num2, out double result)
    {
        result = num1 - num2;
    }


}