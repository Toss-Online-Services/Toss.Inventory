using Catalog.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddProblemDetails();

var withApiVersioning = builder.Services.AddApiVersioning();

builder.AddDefaultOpenApi(withApiVersioning);

var app = builder.Build();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

// Enable middleware to serve generated Swagger as a JSON endpoint
app.UseSwagger();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));


app.MapEndpoints();
app.Run();
