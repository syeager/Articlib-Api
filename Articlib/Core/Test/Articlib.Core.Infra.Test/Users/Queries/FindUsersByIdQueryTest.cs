using Articlib.Core.Infra.Users;
using LittleByte.Extensions.AutoMapper;
using LittleByte.Test.EntityFramework;
using NUnit.Framework;

namespace Articlib.Core.Infra.Test.Users.Queries;

public class FindUsersByIdQueryTest
{
    private FindUsersByIdQuery testObj = null!;
    private UsersContext usersContext = null!;

    [SetUp]
    public void SetUp()
    {
        DbContextFactory.InMemory(ref usersContext!);
        var mapper = new NullObjectMapper();
        testObj = new FindUsersByIdQuery(usersContext, mapper);
    }

    [Test]
    public async Task Given_AllUniqueIds_Then_IterateAll()
    {
        var entities = TV.Users.NewUsers(2);
        usersContext.AddRangeAndSave(entities);

        var ids = entities.Select(u => u.Id).ToArray();

        var result = await testObj.SendAsync(ids);

        Assert.AreEqual(ids.Length, result.Count);
    }

    // TODO: Check sql to make sure dupe ids aren't checked.
    [Test]
    public async Task Given_DupeIds_Then_Dedupe()
    {
        var entity = TV.Users.NewUser();
        usersContext.AddAndSave(entity);

        var ids = new[] {entity.Id, entity.Id};

        var result = await testObj.SendAsync(ids);

        Assert.AreEqual(1, result.Count);
    }
}