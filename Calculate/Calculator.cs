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

    public static void Add<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Convert.ToDouble(num1,new CultureInfo("en-US")) + Convert.ToDouble(num2,new CultureInfo("en-US"));

    public static void Subtract<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Convert.ToDouble(num1,new CultureInfo("en-US")) - Convert.ToDouble(num2,new CultureInfo("en-US"));

    public static void Multiply<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Math.Round(Convert.ToDouble(num1,new CultureInfo("en-US")) * Convert.ToDouble(num2,new CultureInfo("en-US")),12);

    public static void Divide<T, T2>(T num1, T2 num2, out double result) where T : IConvertible where T2 : IConvertible => result = Math.Round(Convert.ToDouble(num2,new CultureInfo("en-US")) == 0 ? throw new DivideByZeroException() : Convert.ToDouble(num1,new CultureInfo("en-US")) / Convert.ToDouble(num2,new CultureInfo("en-US")),12);

    public bool TryCalculate(string input, out double result)
    {
        result = double.NaN;

        string[] split = input.Split(' ');
        

        try
        {
            if (split.Length != 3) throw new ArgumentException("Invalid passed in string: " + input);
            double left = Convert.ToDouble(split[0], new CultureInfo("en-US"));
            double right = Convert.ToDouble(split[2], new CultureInfo("en-US"));
            char givenOperator = Convert.ToChar(split[1], new CultureInfo("en-US"));
            MathematicalOperations[givenOperator](left,right,out result);

        }
        catch (Exception)
        {
            return false;
            
        }

        return true;

    }
}
