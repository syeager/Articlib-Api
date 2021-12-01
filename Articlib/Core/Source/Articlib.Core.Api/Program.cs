using Articlib.Core.Api.Configuration;
using Articlib.Core.Infra.Logging;
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
    .AddDomain()
    .AddInfra()
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
