using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests;

[TestClass]
public class AttributesTests
{
    [TestMethod, MyCustom("Attributes Test")]
    public void AttributesTest()
    {
        typeof(AttributesTests).GetMethod(nameof(AttributesTest))?
        .GetCustomAttributes(false).Select(item => item.GetType())
        .Should().Contain(typeof(TestMethodAttribute));
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class MyCustomAttribute(string displayName) : Attribute
{
    public string DisplayName { get; } = displayName;


    public MyCustomAttribute? GetAttribute(MethodInfo info)
    {
        return info.GetCustomAttribute<MyCustomAttribute>();
    }
}
