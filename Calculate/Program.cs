// See https://aka.ms/new-console-template for more information
﻿using System;
namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }

    public Program()
    {
        WriteLine = Console.WriteLine!;
        ReadLine = Console.ReadLine!;
    }
    public static void Main()
    {
        var calculator = new Calculator();
        var program = new Program();

        do
        {
            program.WriteLine("Enter an arithmetic Operation to calculate (Ex, 4 + 3) : ");
            var input = program.ReadLine();
            if (input != null && calculator.TryCalculate(input, out var result))
            {
                program.WriteLine($"Solution : {result}");
                break;
            }
            else
            {
                program.WriteLine("Invalid input.");
            }
        }while (true);
    }


}




