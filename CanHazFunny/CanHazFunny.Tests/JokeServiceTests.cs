
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;

[TestClass]
public class JokeServiceTests
{
    [TestMethod]
    public void GetJoke_NoArgs_ReturnsJoke()
    {
        // Arrange
        JokeService service = new();
        string joke;

        // Act
        joke = service.GetJoke();

        // Assert
        Assert.IsNotNull(joke);
        Assert.AreNotEqual("", joke);
        //Assert.AreEqual("hi", joke); //Uncomment line to see result
    }
}
