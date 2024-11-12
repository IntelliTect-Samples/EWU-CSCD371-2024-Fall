using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Collections.Generic;
using System.Reflection;

namespace Calculate;

public class Calculator
{
    //private IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations;


    //public Calculator()
    //{
    //    MathematicalOperations = new Dictionary<char, Action<int,int,out int>>
    //    {
    //        { '-', Subtract },
    //        { '+', Add },
    //        { '/', Divide },
    //        { '*', Multiply },
    //    };
    //}

    //public static int Add(int first, int second, out int res)
    //{
    //    return res = first + second;
    //}

    //public static int Subtract(int first, int second, out int res)
    //{
    //    return res = first - second;
    //}
    
    //public static int Multiply(int first, int second, out int res)
    //{
    //    return res = first * second;
    //}

    //public static int Divide(int first, int second, out int res)
    //{
    //    return res = first / second;
    //}

    //public bool TryCalculate(string s)
    //{
    //    string[] sArray = s.Split(" ");
    //    int first;
    //    int second;
    //    char op;
    //    if (sArray.Length == 3 && Int32.TryParse(sArray[0], out first) && Int32.TryParse(sArray[2], out second))
    //    {
    //        Char.TryParse(sArray[1], out op);
    //        Func<int,int,int> target = MathematicalOperations[op];
    //        target(first, second);
    //        return true;
    //    }
    //    return false;
    //}

}
