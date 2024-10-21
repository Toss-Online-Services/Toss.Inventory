using System.Reflection.Emit;
using Infrastructure.EntityConfigurations;
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
    //public DbSet<Product> Products { get; set; }
    // Method to expose the connection string
    public string GetConnectionString()
    {
        // If you're using SQL Server or PostgreSQL, the connection string is part of the underlying database connection
        return this.Database.GetDbConnection().ConnectionString;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("vector");        
        builder.ApplyConfiguration(new ProductConfiguration());
        //builder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);
        // Add the outbox table to this context
        //builder.UseIntegrationEventLogs();
    }
}
