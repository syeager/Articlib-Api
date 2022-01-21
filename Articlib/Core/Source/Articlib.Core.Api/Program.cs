using Articlib.Core.Api.Articles;
using Articlib.Core.Api.Users;
using Articlib.Core.Api.Votes;
using Articlib.Core.Infra.Persistence;
using LittleByte.Core.Dates;
using LittleByte.Extensions.AspNet.Configuration;
using LittleByte.Extensions.AspNet.Middleware;
using LittleByte.Extensions.AspNet.Unleash;
using LittleByte.Identity.Configuration;
using LittleByte.Logging.Configuration;
using LittleByte.Messaging.Configuration;
using Prometheus;
using Unleash;
using Unleash.ClientFactory;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOpenApi("Core");

builder.Services
    .AddLogs()
    .AddTransient<IDateService, DateService>()
    .AddUsers()
    .AddArticles()
    .AddVotes()
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
    .AddPersistence(builder.Configuration)
    .AddMessaging(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration);

builder.Services.AddSingleton<IUnleash>(services =>
{
    var configuration = services.GetRequiredService<IConfiguration>();
    var options = configuration.GetValue<UnleashOptions>(nameof(UnleashOptions));
    var unleashFactory = new UnleashClientFactory();
    var unleash = unleashFactory.CreateClient(options, true);
    return unleash;
});

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
