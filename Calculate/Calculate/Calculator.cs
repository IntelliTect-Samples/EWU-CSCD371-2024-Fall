using System;
using System.Collections.Generic;

namespace Calculate;

public delegate void MathOperation(double num1, double num2, out double result);

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

    public static void Add<T, U>(T num1, U num2, out double result) where T : IConvertible where U : IConvertible => result = Convert.ToDouble(num1) + Convert.ToDouble(num2);

    public static void Subtract<T, U>(T num1, U num2, out double result) where T : IConvertible where U : IConvertible => result = Convert.ToDouble(num1) - Convert.ToDouble(num2);

    public static void Multiply<T, U>(T num1, U num2, out double result) where T : IConvertible where U : IConvertible => result = Math.Round(Convert.ToDouble(num1) * Convert.ToDouble(num2),12);

    public static void Divide<T, U>(T num1, U num2, out double result) where T : IConvertible where U : IConvertible => result = Math.Round(Convert.ToDouble(num2) == 0 ? throw new DivideByZeroException() : Convert.ToDouble(num1) / Convert.ToDouble(num2),12);

    public bool TryCalculate(string input, out double result)
    {
        result = double.NaN;

        string[] split = input.Split(' ');
        if (split.Length != 3) throw new ArgumentException("Invalid passed in string: " + input);

        try
        {
            double left = Convert.ToDouble(split[0]);
            double right = Convert.ToDouble(split[2]);
            char givenOperator = Convert.ToChar(split[1]);
            MathematicalOperations[givenOperator](left,right,out result);

        }
        catch (Exception)
        {
            return false;
            
        }

        return true;

    }
}