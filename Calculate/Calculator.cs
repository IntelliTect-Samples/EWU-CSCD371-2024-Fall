using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;

public class Calculator
{

    public static double Add(int i, int j) => i + j;
    public static double Subtract(int i, int j) => i - j;
    public static double Multiply(int i, int j) => i * j;
    public static double Divide(int i, int j)
    {
        if (j == 0)
        {
            throw new DivideByZeroException();
        }
        return (double)i / (double)j;
    }

    public IReadOnlyDictionary<char, Func<int, int, double>> ArithmeticOperators { get;} = new Dictionary<char, Func<int, int, double>>
    {
        ['+'] = Add,
        ['-'] = Subtract,
        ['*'] = Multiply,
        ['/'] = Divide
    };

    public bool TryCalculate(string equation, out double result)
    {
        result = 0.0;
        string[] parts = equation.Split(' ');

        if (parts.Length != 3) return false;

        if (!int.TryParse(parts[0], out var i)) return false;
        if (!int.TryParse(parts[2], out var j)) return false;

        if (parts[1].Length != 1) return false;
       
        if (!ArithmeticOperators.TryGetValue(parts[1][0], out var operation)) return false;

        result = operation(i, j);
        return true;
    }
}
