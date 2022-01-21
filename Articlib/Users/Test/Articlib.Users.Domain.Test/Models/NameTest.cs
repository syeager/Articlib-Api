using Articlib.Users.Domain.Models;
using NUnit.Framework;

namespace Articlib.Users.Domain.Test.Models;

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
