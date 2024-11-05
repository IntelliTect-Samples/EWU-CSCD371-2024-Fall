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

    public static void Add<T>(T num1, T num2, out double result) where T  : IConvertible=> result = Convert.ToDouble(num1) + Convert.ToDouble(num2);

    public static void Subtract<T>(T num1, T num2, out double result) where T : IConvertible => result = Convert.ToDouble(num1) - Convert.ToDouble(num2);

    public static void Multiply<T>(T num1, T num2, out double result) where T : IConvertible => result = Convert.ToDouble(num1) * Convert.ToDouble(num2);

    public static void Divide<T>(T num1, T num2, out double result) where T : IConvertible => result = Convert.ToDouble(num2) == 0 ? throw new DivideByZeroException() : Convert.ToDouble(num1) / Convert.ToDouble(num2);

}