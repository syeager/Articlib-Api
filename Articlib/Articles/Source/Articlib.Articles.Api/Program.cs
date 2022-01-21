using Articlib.Articles.Api;
using LittleByte.Core.Dates;
using LittleByte.Extensions.AspNet;
using LittleByte.Extensions.AspNet.Middleware;
using LittleByte.Logging.Configuration;
using LittleByte.Messaging.Configuration;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOpenApi("Articles");

builder.Services
    .AddTransient<IDateService, DateService>()
    .AddArticles(builder.Configuration)
    .AddAutoMapper()
    .AddMessaging(builder.Configuration)
    .AddLogs();

var app = builder.Build();
app.UseSerilogRequestLogging();

if(app.Environment.IsDevelopment())
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
    .UseAuthentication()
    .UseRouting()
    .UseAuthorization()
    .UseHttpMetrics()
    .UseHttpExceptions()
    .UseModelValidationExceptions()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapMetrics();
    })
    .UseOpenApi();

app.Run();
