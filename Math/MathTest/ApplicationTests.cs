using MathExtensions;

namespace MathTest;

[TestClass]
public class ApplicationTests
{
    [TestMethod]
    public void Login_InigoMontoyaAndGoodPassword_Success()
    {
        // Arrange
        string username = "Inigo Montoya";
        string password = "good password";
        // Act
        Application application = new();
        bool result = application.Login(username, password);

        // Assert
        Assert.IsTrue(result);
    }

    //[TestMethod]
    //public void Login_InigoMontoyaAndBadPassword_Failure()
    //{
    //    // Arrange
    //    string username = "Inigo Montoya";
    //    string password = "bad password";
    //    // Act
    //    Application application = new();
    //    bool result = application.Login(username, password);
    //    // Assert
    //    Assert.IsFalse(result);
    //}
}