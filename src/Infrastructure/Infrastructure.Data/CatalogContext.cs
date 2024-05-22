using System.Reflection;
using Domain.Entities.Catalog;
using Domain.Entities.Product;
using Infrastructure.IntegrationEventLogEF;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data;

/// <remarks>
/// Add migrations using the following command inside the 'Catalog.API' project directory:
///
/// dotnet ef migrations add --context CatalogContext [migration-name]
/// </remarks>
public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options, IConfiguration configuration) : base(options)
    {
    }

    public DbSet<CatalogItem> CatalogItems { get; set; }
    public DbSet<CatalogBrand> CatalogBrands { get; set; }
    public DbSet<CatalogType> CatalogTypes { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("vector");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Add the outbox table to this context
        builder.UseIntegrationEventLogs();
    }
}
