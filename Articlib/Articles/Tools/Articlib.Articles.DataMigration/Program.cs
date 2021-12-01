using Articlib.Articles.Infra;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        context.Configuration.GetSection("ConnectionStrings")["Articlib"] = "Server=database;Database=Articlib;Uid=dev;Pwd=pass;";

        services
            .AddScoped(serviceProvider => new MapperConfiguration(config => config.AddPersistence(serviceProvider)).CreateMapper());
    })
    .Build()
    .Run();