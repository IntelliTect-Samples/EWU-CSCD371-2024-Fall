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
    public static bool Add(double left, double right, out double result)
    {
        return (result = left + right) == result;
    }
    public static bool Subtract(double left, double right, out double result)
    {
        return (result = left - right) == result;
    }

    public static bool Multiply(double left, double right, out double result)
    {
        return (result = left * right) == result;
    }
    public static bool Divide(double left, double right, out double result)
    {
        return right == 0 ? throw new DivideByZeroException() : (result = left / right) == result;
    }

    public delegate bool MathOperation(double left, double right, out double result);

    public IReadOnlyDictionary<char, MathOperation> MathematicalOperations { get; }
        = new Dictionary<char, MathOperation>
    {
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide
    };

    public bool TryCalculate(string input, out double result)
    {
        //init result to 0.0
        result = 0.0;
        //split the input string by spaces
        string[] parts = input.Split(' ');
        //check if the parts length is not equal to 3
        if (parts.Length != 3) return false;
        //check if the first and last parts are not doubles
        if (!double.TryParse(parts[0], out var left)) return false;
        if (!double.TryParse(parts[2], out var right)) return false;
        //check if middle part is of length 1
        if (parts[1].Length != 1) return false;
        //retrieve the cooresponding operation from the dictionary
        if (!MathematicalOperations.TryGetValue(parts[1][0], out var operation)) return false;
        //result = operation(left, right);
        operation(left, right, out result);
        return true;
    }
}
