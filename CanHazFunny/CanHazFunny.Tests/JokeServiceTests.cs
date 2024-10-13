using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests;
    public class JokeServiceTests
    {
        [Fact]
        public void JokeServiceInterface_UseMoq_Success()
        {
            // Arrange
            var jokeService = new Moq.Mock<IJokeService>();
            jokeService.Setup(x => x.GetJoke()).Returns("Why did the chicken cross the road? To get to the other side.");

            // Act
            var joke = jokeService.Object.GetJoke();

            // Assert
            Assert.Equal("Why did the chicken cross the road? To get to the other side.", joke);
        }
    }
