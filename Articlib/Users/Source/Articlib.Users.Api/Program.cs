using Articlib.Articles.Infra;
using Articlib.Users.Api;
using LittleByte.Extensions.AspNet;
using Prometheus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Articlib";
    options.DocumentName = "Users";
});

builder.Services
    .AddPersistence(builder.Configuration)
    .AddAutoMapper()
    .AddLogs();

var app = builder.Build();
app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseRouting()
    .UseHttpMetrics();

app.MapControllers();

app
    .UseOpenApi()
    .UseSwaggerUi3();

app.Run();
