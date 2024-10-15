using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{

    [Fact]
    public void GetJoke_Called_ReturnsNotNullOrEmpty()
    {
        var service = new JokeService();
        Assert.NotNull(service.GetJoke());
        Assert.NotEmpty(service.GetJoke());
    }

    [Fact]
    public void GetJoke_Called_ReturnsValidString()
    {
        var service = new JokeService();
        Assert.IsType<string>(service.GetJoke());
    }

}