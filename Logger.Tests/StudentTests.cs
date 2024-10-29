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
        public void Constructor_InitializedStudent_Success()
        {
            FullName fullName = new("Inigo", "Montoya");
            Student student = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");

            Assert.NotNull(student);
            Assert.Equal("Inigo Montoya", student.Name);
            Assert.Equal("imontoya1", student.Id);
            Assert.Equal(1, student.SchoolYear);
            Assert.True(student.IsUndergrad);
            Assert.Equal(4.0, student.Gpa);
            Assert.Equal("Revenge", student.Major);
        }

        [Fact]
        public void Constructor_SetNullStudentId_ThrowsArgumentNullException()
        {
            FullName fullName = new("Inigo", "Montoya");

            Assert.Throws<ArgumentNullException>(() => new Student(fullName, null!, 1, true, 4.0, "Revenge"));
        }

        [Fact]
        public void Constructor_SetSchoolYearLessThanOne_ThrowsArgumentOutOfRangeException()
        {
            FullName fullName = new("Inigo", "Montoya");

            Assert.Throws<ArgumentOutOfRangeException>(() => new Student(fullName, "imontoya1", 0, true, 4.0, "Revenge"));
        }

        [Fact]
        public void Constructor_SetInvalidGpa_ThrowsArgumentOutOfRangeException()
        {
            FullName fullName = new("Inigo", "Montoya");

            Assert.Throws<ArgumentOutOfRangeException>(() => new Student(fullName, "imontoya1", 1, true, -1.0, "Revenge"));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Student(fullName, "imontoya1", 1, true, 5.0, "Revenge"));
        }

        [Fact]
        public void Constructor_SetInvalidMajor_ThrowsArgumentException()
        {
            FullName fullName = new("Inigo", "Montoya");

            Assert.Throws<ArgumentNullException>(() => new Student(fullName, "imontoya1", 1, true, 4.0, null!));
            Assert.Throws<ArgumentException>(() => new Student(fullName, "imontoya1", 1, true, 4.0, ""));
        }

        [Fact]
        public void Constructor_ComparesStudents_Success()
        {
            FullName fullName = new("Inigo", "Montoya");
            Student student1 = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");
            Student student2 = new(fullName, "imontoya1", 1, true, 4.0, "Revenge");
            Student student3 = student1;

            Assert.NotEqual(student1, student2);
            Assert.Equal(student1, student3);
            Assert.Same(student1, student3);
        }
    }
}
