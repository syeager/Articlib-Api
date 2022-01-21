using Articlib.Users.Api;
using Articlib.Users.Api.Mappings;
using LittleByte.Extensions.AspNet;
using LittleByte.Extensions.AspNet.Middleware;
using LittleByte.Identity.Configuration;
using LittleByte.Logging.Configuration;
using LittleByte.Messaging.Configuration;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();

builder.Services
    .AddOpenApi("Users")
    .AddUsers(builder.Configuration)
    .AddAutoMapper()
    .AddMessaging(builder.Configuration)
    .AddLogs();

builder.Services
    .AddJwtAuthentication(builder.Configuration);

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
