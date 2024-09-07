using System.Reflection;
using Application.Behaviors;
using Application.IntegrationEvents;
using Application.Products.Models.Product;
using Application.Services;
using Domain.Entities;
using Infrastructure.Idempotency;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Toss.Extensions;

namespace Application.Extensions;

public static partial class Extensions
{   
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;       

        // Pooling is disabled because of the following error:
        // Unhandled exception. System.InvalidOperationException:
        // The DbContext of type 'ApplicationContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("inventorydb"));
        });
        builder.EnrichNpgsqlDbContext<ApplicationContext>();

        services.AddMigration<ApplicationContext>();

        // Add the integration services that consume the DbContext
        services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<ApplicationContext>>();

        services.AddTransient<IOrderingIntegrationEventService, OrderingIntegrationEventService>();

        builder.AddRabbitMqEventBus("eventbus")
               .AddEventBusSubscriptions();

        services.AddHttpContextAccessor();
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        // Register the command validators for the validator behavior (validators based on FluentValidation library)      

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRequestManager, RequestManager>();
    }

    private static void AddEventBusSubscriptions(this IEventBusBuilder eventBus)
    {

    }
}
