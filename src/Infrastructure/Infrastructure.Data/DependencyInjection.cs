using Domain.Repositories;
using Infrastructure.Data.Interceptors;
using Infrastructure.Data.Repositories;
using Infrastructure.IntegrationEventLogEF.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IHostApplicationBuilder builder, IConfiguration configuration)
    {
        var services = builder.Services;

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();


        builder.AddNpgsqlDbContext<CatalogContext>("catalogdb", configureDbContextOptions: dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseNpgsql(builder =>
            {
                builder.UseVector();
            });
        });
        // REVIEW: This is done for development ease but shouldn't be here in production
        builder.Services.AddMigration<CatalogContext>();

        // Add the integration services that consume the DbContext
        services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<CatalogContext>>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddSingleton(TimeProvider.System);
       

        return services;
    }
}
