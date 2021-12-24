using Articlib.Core.Api.Articles;
using Articlib.Core.Api.Configuration;
using Articlib.Core.Api.Users;
using Articlib.Core.Infra.Configuration;
using Articlib.Core.Infra.Messaging;
using LittleByte.Extensions.AspNet;
using LittleByte.Extensions.AspNet.Middleware;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Articlib - Core";
    options.DocumentName = "core";
});

builder.Services
    .AddArticles(builder.Configuration)
    .AddUsers(builder.Configuration)
    .AddAutoMapper()
    .AddMessaging(builder.Configuration)
    .AddLogs();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    //.UseAuthentication()
    .UseRouting()
    //.UseAuthorization()
    .UseHttpMetrics()
    .UseHttpExceptions()
    .UseModelValidationExceptions()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapMetrics();
    })
    .UseOpenApi()
    .UseSwaggerUi3();

app.Run();
