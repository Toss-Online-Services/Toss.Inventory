using Application.Extensions;
using AspNetCore.Swagger.Themes;
using Toss.ServiceDefaults;
using Web;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.AddApplicationServices();
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddWebServices();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        builder => builder
            .WithOrigins("http://localhost:4200") // Allow requests from the Angular client
            .AllowAnyMethod()                      // Allow any HTTP methods (GET, POST, etc.)
            .AllowAnyHeader()                      // Allow any headers
            .AllowCredentials());                  // Allow credentials if needed
});

// Add the authentication services to DI
builder.AddDefaultAuthentication();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

// Enable CORS before the endpoints are mapped
app.UseCors("AllowAngularClient");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseSwaggerUI(ModernStyle.Dark);

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();
