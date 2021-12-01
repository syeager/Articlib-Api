﻿using Articlib.Core.Domain.Users;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users.Models;

public class NameTest
{
    [Test]
    public void When_CastToString_Return_Value()
    {
        const string expected = "bob";

        var name = new Name(expected);

        Assert.AreEqual(expected, (string)name);
    }
}