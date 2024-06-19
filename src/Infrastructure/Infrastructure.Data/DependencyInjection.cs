using Domain.Repositories;
using Infrastructure.Data.Interceptors;
using Infrastructure.Data.Repositories;
using Infrastructure.IntegrationEventLogEF.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using FluentMigrator;
using Infrastructure.Data.Models;
namespace Infrastructure.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IHostApplicationBuilder builder, IConfiguration configuration)
    {
        var services = builder.Services;
        var connectionString = configuration.GetConnectionString("catalogdb");

        Guard.Against.Null(connectionString, message: "Connection string 'catalogdb' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<CatalogContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.UseVector();
            });
        });

        if (builder.Environment.IsDevelopment())
        {
            // REVIEW: This is done for development ease but shouldn't be here in production
            builder.Services.AddMigration<CatalogContext>();

            ///InitializeDatabase();
        }

        // Add the integration services that consume the DbContext
        services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<CatalogContext>>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddSingleton(TimeProvider.System);
       

        return services;
    }    
}
