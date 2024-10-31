using Xunit;

namespace Logger.Tests;

    public class StudentTests
    {
        [Fact]
        public void CreateStudentValidParametersReturnsStudentObject()
        {
            // Arrange
            var FullName = new FullName
            {
                 FirstName = "John",
                 MiddleName = "Doe",
                 LastName = "Smith"
            };
            string ssn = "123-45-6789";
            string email = "john.smith@example.com";
            string dateOfBirth = "1990-01-01";
            string schoolYear = "Senior";
            string major = "Computer Science";

            // Act
            var student = new Student(FullName.FirstName, FullName.MiddleName, FullName.LastName, ssn, email, dateOfBirth, schoolYear, major);

            // Assert
            Assert.Equal(FullName.ToString(), student.FullName.ToString());
            Assert.Equal(FullName, student.FullName);
            Assert.Equal(ssn, student.Ssn);
            Assert.Equal(email, student.Email);
            Assert.Equal(dateOfBirth, student.DateOfBirth);
            Assert.Equal(schoolYear, student.SchoolYear);
            Assert.Equal(major, student.Major);
        }
        [Fact]
        public void BaseEntityIdInitializedReturnsValidId()
        {
            // Arrange
            var student = new Student("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Senior", "Computer Science" );

            // Act
            var studentEntity = (IEntity)student;
            var id = studentEntity.Id;
            

            // Assert
            Assert.NotEqual(Guid.Empty, id);
        }
        
    }
