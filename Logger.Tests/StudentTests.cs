using Xunit;

namespace Logger.Tests;
    public class StudentTests
    {
        [Fact]
        public void Student_CreationWithValidData_SuccessfullyCreatesInstance()
        {
            // Arrange
            var firstName = "Geralt";
            var middleName = "Of";
            var lastName = "Rivia";
            var email = "geralt@witcher.school.com";
            var schoolName = "School of the Wolf";
            var major = "Monster Hunting";
            var ssn = "123-45-6789"; // Fake SSN
            var dob = "11-15-1160"; // Geralt's fake Date of Birth in MM-DD-YYYY format
            var age = 100;
            var schoolYear = 1260;

            // Act
            var student = new Student(firstName, middleName, lastName, email, schoolName, schoolYear, major, ssn, age, dob);

            // Assert
            Assert.NotNull(student);
            Assert.Equal(firstName, student.PersonsName.FirstName);
            Assert.Equal(middleName, student.PersonsName.MiddleName);
            Assert.Equal(lastName, student.PersonsName.LastName);
            Assert.Equal(email, student.Email);
            Assert.Equal(schoolName, student.SchoolName);
            Assert.Equal(major, student.Major);
            Assert.Equal(ssn, student.Ssn);
            Assert.Equal(age, student.Age);
            Assert.Equal(dob, student.DateOfBirth);
            Assert.Equal(schoolYear, student.SchoolYear);
        }

        [Fact]
        public void Student_AssignedIdUponCreation_IdIsNotEmpty()
        {
            // Arrange
            var student = new Student("Yennefer", null, "Vengerberg", "yennefer@magic.academy.com", 
                "Aretuza", 1260, "Sorcery", "987-65-4321", 100, "05-01-1173");

            // Act
            var studentEntity = (IEntity)student;
            var studentId = studentEntity.Id;

            // Assert
            Assert.NotEqual(Guid.Empty, studentId);
        }

        [Fact]
        public void Student_NameWithMiddleName_ReturnsFullNameIncludingMiddleName()
        {
            // Arrange
            var student = new Student("Geralt", "Of", "Rivia", "geralt@witcher.school.com", 
                "School of the Wolf", 1260, "Monster Hunting", "123-45-6789", 100, "11-15-1160");

            // Act
            var result = student.Name;

            // Assert
            Assert.Equal("Geralt Of Rivia", result);
        }

        [Fact]
        public void Student_NameWithoutMiddleName_ReturnsFullNameWithoutMiddleName()
        {
            // Arrange
            var student = new Student("Yennefer", null, "Vengerberg", "yennefer@magic.academy.com", 
                "Aretuza", 1260, "Sorcery", "987-65-4321", 100, "05-01-1173");

            // Act
            var result = student.Name;

            // Assert
            Assert.Equal("Yennefer Vengerberg", result);
        }

        [Fact]
        public void Student_ThrowsArgumentException_WhenEmailIsNullOrEmpty()
        {
            // Act & Assert
            var exceptionEmptyEmail = Assert.Throws<ArgumentException>(() => new Student("Geralt", "Of", "Rivia", string.Empty, 
                "School of the Wolf", 1260, "Monster Hunting", "123-45-6789", 100, "11-15-1160"));
            Assert.Equal("Email cannot be null or empty. (Parameter 'email')", exceptionEmptyEmail.Message);
        }

        [Fact]
        public void Student_ThrowsArgumentException_WhenSchoolNameIsNullOrEmpty()
        {
            // Act & Assert
            var exceptionEmptySchoolName = Assert.Throws<ArgumentException>(() => new Student("Geralt", "Of", "Rivia",
                "geralt@witcher.school.com",
                string.Empty, 1260, "Monster Hunting", "123-45-6789", 100, "11-15-1160"));
            Assert.Equal("School name cannot be null or empty. (Parameter 'schoolName')", exceptionEmptySchoolName.Message);
        }

        [Fact]
        public void Student_ThrowsArgumentException_WhenMajorIsNullOrEmpty()
        {
            // Act & Assert
            var exceptionEmptyMajor = Assert.Throws<ArgumentException>(() => new Student("Geralt", "Of", "Rivia", "geralt@witcher.school.com", 
                "School of the Wolf", 1260, string.Empty, "123-45-6789", 100, "11-15-1160"));
            Assert.Equal("Major cannot be null or empty. (Parameter 'major')", exceptionEmptyMajor.Message);
        }

        [Fact]
        public void Student_Equality_WhenInstancesHaveSameData_ReturnsTrue()
        {
            // Arrange
            string firstName = "Vannessa";
            string middleName = String.Empty;
            string lastName = "Perez";
            string email = "vannessa@jmh.edu";
            string schoolName = "James Monroe High School";
            string major = "Electrical Engineering";
            string ssn = "123-45-6789"; // Fake SSN
            string dob = "08-15-1999"; // Vannessa's fake Date of Birth in MM-DD-YYYY formating
            int age = 25;
            int schoolYear = 2017;
            Student student1 = new Student(firstName, middleName, lastName, email, schoolName,
                schoolYear, major, ssn, age, dob);
            Student student2 = student1 with { };
            
            // Act
            bool result = student1.Equals(student2);
            
            // Assert
            Assert.True(result);

        }

        [Fact]
        public void Student_ReferenceEquality_WhenInstancesHaveSameData_ReturnsFalse()
        {
            // Arrange
            string firstName = "Vannessa";
            string middleName = String.Empty;
            string lastName = "Perez";
            string email = "vannessa@jmh.edu";
            string schoolName = "James Monroe High School";
            string major = "Electrical Engineering";
            string ssn = "123-45-6789"; // Fake SSN
            string dob = "08-15-1999"; // Vannessa's fake Date of Birth in MM-DD-YYYY formating
            int age = 25;
            int schoolYear = 2017;
            Student student1 = new Student(firstName, middleName, lastName, email, schoolName,
                schoolYear, major, ssn, age, dob);

            // Act
            bool result = ReferenceEquals(student1, student1 with { });

            // Assert
            Assert.False(result);
        }

    }

