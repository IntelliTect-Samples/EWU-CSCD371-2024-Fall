namespace Calculate;

public class Calculator
{
    public static int Add(int num1, int num2, out int result) => result = num1 + num2;

    public static int Subtract(int num1, int num2, out int result) => result = num1 - num2;

    public static int Multiply(int num1, int num2, out int result) => result = num1 * num2;

    public static int Divide(int num1, int num2, out int result)
    {
        return num2 == 0 ? throw new DivideByZeroException() : (result = num1 / num2);
    }
}