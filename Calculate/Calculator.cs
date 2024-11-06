using System;
using System.Collections.Generic;
using System.Globalization;

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

    public static void Add<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Convert.ToDouble(num1, new CultureInfo("en-US")) + Convert.ToDouble(num2, new CultureInfo("en-US"));

    public static void Subtract<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Convert.ToDouble(num1, new CultureInfo("en-US")) - Convert.ToDouble(num2, new CultureInfo("en-US"));

    public static void Multiply<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Math.Round(Convert.ToDouble(num1, new CultureInfo("en-US")) * Convert.ToDouble(num2, new CultureInfo("en-US")), 12);

    public static void Divide<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Math.Round(Convert.ToDouble(num2, new CultureInfo("en-US")) == 0 ? throw new DivideByZeroException() : Convert.ToDouble(num1, new CultureInfo("en-US")) / Convert.ToDouble(num2, new CultureInfo("en-US")), 12);

    public bool TryCalculate(string input, out double result)
    {
        result = double.NaN;

        string[] split = input.Split(' ');
        if (split.Length != 3) return false;

        if (!double.TryParse(split[0], out double left) || !double.TryParse(split[2], out double right))
        {
            return false;
        }

        if (split[1].Length != 1 || !MathematicalOperations.ContainsKey(split[1][0]))
        {
            return false;
        }

        char givenOperator = split[1][0];
        MathematicalOperations[givenOperator](left, right, out result);

        return true;
    }
}