using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_
{
    public class Calculator
    {
        private static readonly IReadOnlyDictionary<char, Func<int, int, double>> _mathematicalOperations =
            new Dictionary<char, Func<int, int, double>>
            {
                    { '+', (a, b) => Add(a, b) },
                    { '-', (a, b) => Subtract(a, b) },
                    { '', (a, b) => Multiply(a, b) },
                    { '/', (a, b) => Divide(a, b) }
            };

        public static IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations => _mathematicalOperations;

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a b;
        }

        public static double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return (double)a / b;
        }

        public static bool TryCalculate(string expression, out double result)
        {
            result = 0;
            var parts = expression.Split(' ');

            if (parts.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(parts[0], out int operand1) || !int.TryParse(parts[2], out int operand2))
            {
                return false;
            }

            char operation = parts[1][0];

            if (!MathematicalOperations.TryGetValue(operation, out var func))
            {
                return false;
            }

            result = func(operand1, operand2);
            return true;
        }
    }
}