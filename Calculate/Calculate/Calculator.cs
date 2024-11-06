using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculate;

public class Calculator
{
    public static double Add(double left, double right) => left + right;
    public static double Subtract(double left, double right) => left - right;
    public static double Multiply(double left, double right) => left * right;
    public static double Divide(double left, double right) => right == 0 ? throw new DivideByZeroException() : left / right;

    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; }
        = new Dictionary<char, Func<double, double, double>>
    {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide
    };

    // Use string.Split(), pattern matching, logical and operators to parse the string in their entirety ❌✔
    public bool TryCalculate(string input, out double result)
    {
        //init result to 0.0
        result = 0.0;
        //split the input string by space
        string[] parts = input.Split(' ');
        //check if the parts length is not equal to 3
        if (parts.Length != 3) return false;
        //check if the first and last parts are not numbers
        if (!double.TryParse(parts[0], out var left)) return false;
        if (!double.TryParse(parts[2], out var right)) return false;
        //check if middle part is of length 1
        if (parts[1].Length != 1) return false;
        //retrieve the operation from the dictionary
        if (!MathematicalOperations.TryGetValue(parts[1][0], out var operation)) return false;
        result = operation(left, right);
        return true;
    }
}
