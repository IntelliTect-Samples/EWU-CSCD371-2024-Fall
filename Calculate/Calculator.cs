using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Collections.Generic;
using System.Reflection;

namespace Calculate;

public class Calculator
{
    private readonly IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations = new Dictionary<char, Func<int, int, int>>
        {
            { '-', Subtract},
            { '+', Add },
            { '/', Divide },
            { '*', Multiply },
        };


    public Calculator()
    {
    }

    public static int Add(int first, int second)
    {
        return first + second;
    }

    public static int Subtract(int first, int second)
    {
        return first - second;
    }

    public static int Multiply(int first, int second)
    {
        return first * second;
    }

    public static int Divide(int first, int second)
    {
        return first / second;
    }

    public bool TryCalculate(string s, out int result)
    {
        string[] sArray = s.Trim().Split(" ");

        if (sArray.Length == 3 && Int32.TryParse(sArray[0], out int first) && Int32.TryParse(sArray[2], out int second) && Char.TryParse(sArray[1], out char mathOperator) && MathematicalOperations.ContainsKey(mathOperator))
        {
            Func<int, int, int> target = MathematicalOperations[mathOperator];

            result = target(first, second);
            return true;
        }
        result = -1;
        return false;
    }

}
