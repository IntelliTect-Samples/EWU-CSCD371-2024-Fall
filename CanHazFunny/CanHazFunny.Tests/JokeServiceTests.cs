using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    [Fact]
    public void GetJoke_ReturnsJoke_Success() 
    {
        var jokeService = new JokeService();
        var joke = jokeService.GetJoke();
        Assert.NotNull(joke);
    }
}