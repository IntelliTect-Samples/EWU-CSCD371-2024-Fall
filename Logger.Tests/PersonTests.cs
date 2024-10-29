﻿using Xunit;

namespace Logger.Tests;

public class PersonTests
{

    [Fact]
    public void Constructor_InitializedPerson_Success()
    {
        FullName fullName = new("Inigo", "Montoya", "A");
        TestPerson person = new(fullName);

        Assert.NotNull(person);
        Assert.Equal("Inigo A Montoya", person.Name);
    }

    [Fact]
    public void Constructor_GetsGuidAssigned_Success()
    {
        FullName fullName = new("Inigo", "Montoya", "A");
        TestPerson person = new(fullName);

        Assert.NotEqual(Guid.Empty, ((IEntity)person).Id);
    }
}

public record class TestPerson(FullName LegalName) : Person(LegalName)
{
}
