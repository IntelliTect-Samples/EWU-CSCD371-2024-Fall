using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Calculator;

    public class Calculates
    {
        private readonly Dictionary<char, Operation> _mathematicalOperations;
       
        public delegate bool Operation(int a, int b, out double result);
        public Calculates()
        {
            _mathematicalOperations = new Dictionary<char, Operation>();
            {
                _mathematicalOperations.Add( '+', Add );
                _mathematicalOperations.Add( '-', Subtract );
                _mathematicalOperations.Add( '*', Multiply );
                _mathematicalOperations.Add( '/', Divide );
            };
        }
        public static bool Add(int a, int b, out double result)
        {
            result = a + b;
            return true;
        }

        public static bool Subtract(int a, int b, out double result)
        {
            result = a - b;
            return true;
        }

        public static bool Multiply(int a, int b, out double result)
        {
            result = a * b;
            return true;
        }

        public static bool Divide(int a, int b, out double result)
        {
            if (b == 0)
            {
                result = 0;
                return false;
            }
            result = (double)a / b;
            return true;
        }

        public bool TryCalculate(string expression, out double result)
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

            if (!_mathematicalOperations.TryGetValue(operation, out var func))
            {
                return false;
            }

            return func(operand1, operand2, out result);
        }
    }
