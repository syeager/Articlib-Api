using Articlib.Core.Infra.Persistence;
using Articlib.Core.Infra.Users.Queries;
using LittleByte.Extensions.AutoMapper;
using LittleByte.Test.EntityFramework;
using LittleByte.Validation.Test.Categories;
using NUnit.Framework;

namespace Articlib.Core.Infra.Test.Users.Queries;

public class FindUsersByIdQueryTest : UnitTest
{
    private FindUsersByIdQuery testObj = null!;
    private CoreDb coreDb = null!;

    [SetUp]
    public void SetUp()
    {
        var mapper = new NullObjectMapper();
        DbContextFactory.InMemory(ref coreDb!, options => new CoreDb(mapper, options));
        testObj = new FindUsersByIdQuery(coreDb, mapper);
    }

    [Test]
    public async Task Given_AllUniqueIds_Then_IterateAll()
    {
        var entities = TV.Users.NewUsers(2);
        coreDb.AddRangeAndSave(entities);

        var ids = entities.Select(u => u.Id).ToArray();

        var result = await testObj.SendAsync(ids);

        Assert.AreEqual(ids.Length, result.Count);
    }

    // TODO: Check sql to make sure dupe ids aren't checked.
    [Test]
    public async Task Given_DupeIds_Then_Dedupe()
    {
        var entity = TV.Users.NewUser();
        coreDb.AddAndSave(entity);

        var ids = new[] {entity.Id, entity.Id};

        var result = await testObj.SendAsync(ids);

        Assert.AreEqual(1, result.Count);
    }
}
