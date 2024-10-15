using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{

    [Fact]
    public void JokeOutput_ServiceSetNull_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>  new Jester(new JokeOutput(), null!) );
    }

    [Fact]
    public void JokeOutput_OutputSetNull_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, new JokeService()));
    }

    [Fact]
    public void ToLower_PassedValidString_ReturnsLowercaseString()
    {
        string uppercase = "THISISSOMEUPPERCASE";
        Assert.Equal("thisissomeuppercase", uppercase.ToLowerInvariant());
    }

}