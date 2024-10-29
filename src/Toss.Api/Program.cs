using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Toss.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load app settings from JSON files and environment variables
            builder.Configuration.AddJsonFile(NopConfigurationDefaults.AppSettingsFilePath, optional: true, reloadOnChange: true);
            if (!string.IsNullOrEmpty(builder.Environment?.EnvironmentName))
            {
                var path = string.Format(NopConfigurationDefaults.AppSettingsEnvironmentFilePath, builder.Environment.EnvironmentName);
                builder.Configuration.AddJsonFile(path, optional: true, reloadOnChange: true);
            }
            builder.Configuration.AddEnvironmentVariables();

            // Load application settings
            builder.Services.ConfigureApplicationSettings(builder);
            var appSettings = Singleton<AppSettings>.Instance;

            // Set up dependency injection container (Autofac or Default)
            if (appSettings.Get<CommonConfig>().UseAutofac)
            {
                builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            }
            else
            {
                builder.Host.UseDefaultServiceProvider(options =>
                {
                    options.ValidateScopes = false;
                    options.ValidateOnBuild = true;
                });
            }

            // Register services to the DI container
            builder.Services.ConfigureApplicationServices(builder);

            // Set up controllers, endpoints, and Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TOSS ONLINE API", Version = "v1" });
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 100 * 1024 * 1024; // Example: 100 MB limit
            });

            var app = builder.Build();


            // Configure middleware and request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                builder.Services.AddLogging(logging =>
                {
                    logging.AddConsole();
                    logging.AddDebug();
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Custom application request pipeline configuration
            app.ConfigureRequestPipeline();
            await app.StartEngineAsync();

            await app.RunAsync();
        }
    }
}
