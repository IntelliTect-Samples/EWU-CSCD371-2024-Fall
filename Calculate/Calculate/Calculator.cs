using System;
using System.Collections.Generic;

namespace Calculate;

public delegate void MathOperation(int num1, int num2, out double result);

public class Calculator
{
    public IReadOnlyDictionary<char, MathOperation> MathematicalOperations { get; }

    public Calculator()
    {
        MathematicalOperations = new Dictionary<char, MathOperation>
            {
                { '+', Add },
                { '-', Subtract },
                { '*', Multiply },
                { '/', Divide }
            };
    }

    public static void Add(int num1, int num2, out double result) => result = num1 + num2;

    public static void Subtract(int num1, int num2, out double result) => result = num1 - num2;

    public static void Multiply(int num1, int num2, out double result) => result = num1 * num2;

    public static void Divide(int num1, int num2, out double result)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException();
        }
        result = (double)num1 / num2;
    }
}