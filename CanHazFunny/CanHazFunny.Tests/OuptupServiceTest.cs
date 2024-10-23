using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class OuptupServiceTest
{
    [Fact]
    public void WriteJoke_WritesToConsole_Sucess()
    {
        //assert
        var outputService = new OutputService();
        var expectedJoke = "*Funnyst Joke Of All*";
        var stringwriter = new StringWriter();
        Console.SetOut(stringwriter);

        //act
        outputService.WriteJoke(expectedJoke);

        //assert
        Assert.Equal(expectedJoke, stringwriter.ToString().Trim());
    }
}
