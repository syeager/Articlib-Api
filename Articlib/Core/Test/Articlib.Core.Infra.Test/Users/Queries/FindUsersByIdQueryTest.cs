using System.Linq.Expressions;
using Articlib.Core.Infra.Users;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Articlib.Core.Infra.Test.Users.Queries;

// TODO: Move to test lib.
public class NullObjectMapper : IMapper
{
    public TDestination Map<TDestination>(object source)
    {
        return default!;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return default!;
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        return default!;
    }

    public object Map(object source, Type sourceType, Type destinationType)
    {
        return default!;
    }

    public object Map(object source, object destination, Type sourceType, Type destinationType)
    {
        return default!;
    }

    public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions<object, TDestination>> opts)
    {
        return default!;
    }

    public TDestination Map<TSource, TDestination>(TSource source,
        Action<IMappingOperationOptions<TSource, TDestination>> opts)
    {
        return default!;
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination,
        Action<IMappingOperationOptions<TSource, TDestination>> opts)
    {
        return default!;
    }

    public object Map(object source, Type sourceType, Type destinationType,
        Action<IMappingOperationOptions<object, object>> opts)
    {
        return default!;
    }

    public object Map(object source, object destination, Type sourceType, Type destinationType,
        Action<IMappingOperationOptions<object, object>> opts)
    {
        return default!;
    }

    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object? parameters = null,
        params Expression<Func<TDestination, object>>[] membersToExpand)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, IDictionary<string, object> parameters,
        params string[] membersToExpand)
    {
        throw new NotImplementedException();
    }

    public IQueryable ProjectTo(IQueryable source, Type destinationType, IDictionary<string, object>? parameters = null,
        params string[] membersToExpand)
    {
        throw new NotImplementedException();
    }

    public IConfigurationProvider ConfigurationProvider => null!;
    public Func<Type, object> ServiceCtor => null!;
}

public class FindUsersByIdQueryTest
{
    private FindUsersByIdQuery testObj = null!;
    private UsersContext usersContext = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<UsersContext>()
            .UseInMemoryDatabase("Test")
            .Options;
        usersContext = new UsersContext(options);
        var mapper = new NullObjectMapper();
        testObj = new FindUsersByIdQuery(usersContext, mapper);
    }

    [Test]
    public async Task Given_AllUniqueIds_Then_IterateAll()
    {
        var entities = TV.Users.NewUsers(2);
        usersContext.Users.AddRange(entities);
        await usersContext.SaveChangesAsync();
        
        var ids = entities.Select(u => u.Id).ToArray();

        var result = await testObj.SendAsync(ids);

        Assert.AreEqual(ids.Length, result.Count);
    }

    // TODO: Check sql to make sure dupe ids aren't checked.
    [Test]
    public async Task Given_DupeIds_Then_Dedupe()
    {
        var entity = TV.Users.NewUser();
        usersContext.Users.Add(entity);
        await usersContext.SaveChangesAsync();

        var ids = new []{entity.Id, entity.Id};

        var result = await testObj.SendAsync(ids);

        Assert.AreEqual(1, result.Count);
    }
}