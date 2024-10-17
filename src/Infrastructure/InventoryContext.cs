using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

/// <remarks>
/// Add migrations using the following command inside the 'Inventory.API' project directory:
///
/// dotnet ef migrations add --context InventoryContext [migration-name]
/// </remarks>
public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options, IConfiguration configuration) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("vector");
        //builder.ApplyConfiguration(new ProductConfiguration());

        // Add the outbox table to this context
        //builder.UseIntegrationEventLogs();
    }
}
