using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JokeServiceTests
    {
        [TestMethod]
        public void JokeServiceInterface_UseMoq_Success()
        {
            // Arrange
            var jokeService = new Moq.Mock<IJokeService>();
            jokeService.Setup(x => x.GetJoke()).Returns("Why did the chicken cross the road? To get to the other side.");

            // Act
            var joke = jokeService.Object.GetJoke();

            // Assert
            Assert.AreEqual("Why did the chicken cross the road? To get to the other side.", joke);
        }
    }
}
