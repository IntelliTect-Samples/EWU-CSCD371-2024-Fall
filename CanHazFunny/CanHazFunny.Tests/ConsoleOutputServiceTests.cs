using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Xunit;

namespace CanHazFunny.Tests;

public class ConsoleOutputServiceTests
{

    private const int tabSize = 4;
    private const string usageText = "Usage: INSERTTABS inputfile.txt outputfile.txt";

    [Fact]
    public void WriteJoke_ReturnsJoke_Success() 
    {

        //// Arrange
        //var joke = "Funny Joke";
        //var consoleOutput = new ConsoleOutputService();

// Version 1

        //// Act
        //Process compiler = new Process();
        //compiler.StartInfo.FileName = "cmd.exe";
        ////compiler.StartInfo.Arguments = "/c DIR"; // Note the /c command (*)

        //compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
        //compiler.StartInfo.UseShellExecute = false;
        //compiler.StartInfo.RedirectStandardOutput = true;
        //compiler.Start();

        //consoleOutput.WriteJoke(joke);
        //Console.WriteLine(compiler.StandardOutput.ReadToEnd());

        //Console.WriteLine(joke);
        //compiler.WaitForExit();
        //string output = compiler.StandardOutput.ReadToEnd();

        //bool cont = output.Contains(joke);

        ////compiler.StartInfo.UseShellExecute = true;
        ////compiler.StartInfo.RedirectStandardOutput = false;
        ////Console.WriteLine(output);

        // Assert
        //Assert.True(cont);

// Version 2

    //    try
    //    {
    //        // Attempt to open output file.
    //        using (var writer = new StreamWriter("outputFile.txt"))
    //        {
    //            using (var reader = new StreamReader("inputFile.txt"))
    //            {
    //                // Redirect standard output from the console to the output file.
    //                Console.SetOut(writer);
    //                // Redirect standard input from the console to the input file.
    //                Console.SetIn(reader);
    //                string? line;
    //                while ((line = Console.ReadLine()) != null)
    //                {
    //                    string newLine = line.Replace(("").PadRight(tabSize, ' '), "\t");
    //                    Console.WriteLine(newLine);
    //                }
    //                consoleOutput.WriteJoke(joke);
    //                Assert.Contains(joke, writer.ToString());
    //            }
    //        }
    //    }
    //    catch (IOException e)
    //    {
    //        TextWriter errorWriter = Console.Error;
    //        errorWriter.WriteLine(e.Message);
    //        errorWriter.WriteLine(usageText);
    //    }

    //    // Recover the standard output stream so that a
    //    // completion message can be displayed.
    //    var standardOutput = new StreamWriter(Console.OpenStandardOutput());
    //    standardOutput.AutoFlush = true;
    //    Console.SetOut(standardOutput);
    //    Console.WriteLine("INSERTTABS has completed the processing of outputFile.txt.");

    }
}