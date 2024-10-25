using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Logger.Tests
{
    public class StudentTests
    {
        [Fact]
        public void StudenName_SetProperties_Success()
        {
            // Arrange & Act
            var student = new Student(new FullName("Chris", "Cornell", "J"), "Senior", "Computer Science");

            // Assert
            Assert.Equal("Chris J Cornell", student.FullName.ToString());
            Assert.Equal("Senior", student.Year);
            Assert.Equal("Computer Science", student.Major);
        }

        [Fact]
        public void StudentId_UniqueId_Success()
        {
            // Arrange
            var student1 = new Student(new FullName("Chris", "Cornell", "J"), "Senior", "Computer Science");
            var student2 = new Student(new FullName("Someone", "Else", "Blah"), "Sophomore", "Communications");

            // Assert
            Assert.NotEqual(student1.Id, student2.Id);
        }


    }
}
