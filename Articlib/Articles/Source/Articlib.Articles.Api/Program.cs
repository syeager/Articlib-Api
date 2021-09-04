using Articlib.Articles.Api;

var builder = WebApplication.CreateBuilder(args);
builder.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Articlib";
});

builder.Services
    .AddPersistence()
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app
    .UseOpenApi()
    .UseSwaggerUi3();

app.Run();
