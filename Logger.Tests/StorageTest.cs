using Xunit;

namespace Logger.Tests
{
    public class StorageTests
    {
        [Fact]
        public void Add_AddEmployee_SuccessfullyAdded()
        {
            // Arrange
            var storage = new Storage();
            var employee = new Employee("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Software Developer", "IT" );

            // Act
            storage.Add(employee);

            // Assert
            Assert.True(storage.Contains(employee));
        }

        [Fact]
        public void Add_AddStudent_SuccessfullyAdded()
        {
            // Arrange
            var storage = new Storage();
            var student = new Student("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Senior", "Computer Science" );

            // Act
            storage.Add(student);

            // Assert
            Assert.True(storage.Contains(student));
        }

        [Fact]
        public void Remove_RemoveEmployee_SuccessfullyRemoved()
        {
            // Arrange
            var storage = new Storage();
            var employee = new Employee("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Software Developer", "IT" );
            storage.Add(employee);

            // Act
            storage.Remove(employee);

            // Assert
            Assert.False(storage.Contains(employee));
        }

        [Fact]
        public void Remove_RemoveStudent_SuccessfullyRemoved()
        {
            // Arrange
            var storage = new Storage();
            var student = new Student("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Senior", "Computer Science" );
            storage.Add(student);

            // Act
            storage.Remove(student);

            // Assert
            Assert.False(storage.Contains(student));
        }

        [Fact]
        public void Get_GetEmployeeById_ReturnsCorrectEmployee()
        {
            // Arrange
            var storage = new Storage();
            var employee1 = new Employee("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Software Developer", "IT" );
            var employee2 = new Employee("Jane", "Dove", "Smithers", "987-65-4321", "jane.smith@example.com", "1991-02-02", "Junior Developer", "HR");
            storage.Add(employee1);
            storage.Add(employee2);

            // Act
            var result = storage.Get(employee2.Id);

            // Assert
            Assert.Equal(employee2, result);
        }

        [Fact]
        public void Get_GetStudentById_ReturnsCorrectStudent()
        {
            // Arrange
            var storage = new Storage();
            var student1 = new Student("John", "Doe", "Smith", "123-45-6789","john.doe@example.com", "1990-01-01", "Senior", "Computer Science" );
            var student2 = new Student("Jane", "Dove", "Smithers", "987-65-4321", "jane.smith@example.com", "1995-05-10", "Junior", "Biology");
            storage.Add(student1);
            storage.Add(student2);

            // Act
            var result = storage.Get(student1.Id);

            // Assert
            Assert.Equal(student1, result);
        }
    }
}