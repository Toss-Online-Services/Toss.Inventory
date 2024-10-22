using System.Reflection.Emit;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.IntegrationEventLogEF;
using Microsoft.EntityFrameworkCore.Storage;
using MediatR;
using Infrastructure.Extensions;
namespace Infrastructure;

/// <remarks>
/// Add migrations using the following command inside the 'Inventory.API' project directory:
///
/// dotnet ef migrations add --context InventoryContext [migration-name]
/// </remarks>
public class InventoryContext : DbContext, IUnitOfWork
{
    public InventoryContext(DbContextOptions<InventoryContext> options, IConfiguration configuration) : base(options)
    {
    }
    private readonly IMediator _mediator;
    private IDbContextTransaction _currentTransaction;

    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public bool HasActiveTransaction => _currentTransaction != null;

    public InventoryContext(DbContextOptions<InventoryContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


        System.Diagnostics.Debug.WriteLine("OrderingContext::ctor ->" + this.GetHashCode());
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
        //builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfigurationsFromAssembly(typeof(InventoryContext).Assembly);
        // Add the outbox table to this context
        builder.UseIntegrationEventLogs();
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // Dispatch Domain Events collection. 
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
        // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
        // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
        await _mediator.DispatchDomainEventsAsync(this);

        // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
        // performed through the DbContext will be committed
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (HasActiveTransaction)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (HasActiveTransaction)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}

#nullable enable
