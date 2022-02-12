using Articlib.Core.Domain.Users;
using LittleByte.Validation.Test.Categories;
using NUnit.Framework;

namespace Articlib.Core.Domain.Test.Users;

public class NameTest : UnitTest
{
    [Test]
    public void When_CastToString_Return_Value()
    {
        const string expected = "bob";

        var name = new Name(expected);

        Assert.AreEqual(expected, (string)name);
    }
}
