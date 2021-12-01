using Articlib.Articles.Api;
using LittleByte.Extensions.AspNet;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Articlib";
    options.DocumentName = "Articles";
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

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapMetrics();
});

app
    .UseOpenApi()
    .UseSwaggerUi3();

app.Run();
