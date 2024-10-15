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
    public void GetJoke_NullJoke_ThrowException()
    {
        string ?nulledValue = null;
        var mockJokeService = new Mock<IJokeService>();
        mockJokeService.Setup(js => js.GetJoke()).Returns(nulledValue!);


        Assert.Null(mockJokeService.Object.GetJoke());
        Assert.Throws<ArgumentNullException>(() => mockJokeService.Object.GetJoke());
    }

}
