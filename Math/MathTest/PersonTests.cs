using MathExtensions;

namespace MathTest;

[TestClass]
public class PersonTests
{
    [TestMethod]
    public void FirstName_SetProperty_Success()
    {
        Person person = new("Inigo", "Montoya");
        person.FirstName = "Inigo";
        Assert.AreEqual("Inigo", person.FirstName);
    }

    [TestMethod]
    public void FirstName_InitializedPerson_NotNull()
    {
        Person person = new("Inigo", "Montoya");
        Assert.IsNotNull(person.FirstName);
    }

    [TestMethod]
    public void FirstName_Null_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(
            () => new Person(null!, "Montoya"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FirstName_SetNull_ArgumentNullException()
    {
        Person person = new("Inigo", "Montoya");
        person.FirstName = null!;
    }

    [TestMethod]
    public void FirstName_IsEmpty_ArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(
            () => new Person("   ", "Montoya"));
    }

    [TestMethod]
    public void SetName_IsNull_ArgumentNullException()
    {
        Person person = new("Inigo", "Montoya");
        Assert.ThrowsException<ArgumentNullException>(
            () => person.SetName(null!));
    }

    [TestMethod]
    public void Ctor_InigoMontoya_Success()
    {
        Person person = new("Inigo", "Montoya");
        Assert.AreEqual(("Inigo", "Montoya", 42), (person.FirstName, person.LastName, 42));

        (string firstName, string lastName) = person;
        Assert.AreEqual(("Inigo", "Montoya"), (firstName, lastName));

        //Assert.AreEqual(["Inigo", "Montoya"], [person.FirstName, person.LastName]);
        //Assert.AreEqual("Inigo", person.FirstName);
        //Assert.AreEqual("Montoya", person.LastName);
    }



    //[TestMethod]
    //public void LastName_InitializedPerson_NotNull()
    //{
    //    var person = new Person("Inigo", "Montoya");
    //    Assert.IsNotNull(person.LastName);
    //}

    //[TestMethod]
    //public void Ctor_InitializedPerson_SetsProperties()
    //{
    //    var person = new Person("Inigo", "Montoya");
    //    Assert.AreEqual("Inigo", person.FirstName);
    //    Assert.AreEqual("Montoya", person.LastName);
    //}
}
