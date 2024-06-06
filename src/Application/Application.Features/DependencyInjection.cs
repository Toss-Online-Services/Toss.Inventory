using System.Reflection;
using Application.Infrastructure.Behaviours;
using Infrastructure.EventBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Application.Events.IntegrationEvents;
using Application.Infrastructure.Services;

namespace Application.Features;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        builder.AddRabbitMqEventBus("eventbus")
           .AddEventBusSubscriptions();

        services.AddTransient<IIdentityService, IdentityService>();


        return services;
    }
    private static void AddEventBusSubscriptions(this IEventBusBuilder eventBus)
    {
        //eventBus.AddSubscription<ProductStatusChangedToAwaitingValidationIntegrationEvent, ProductStatusChangedToAwaitingValidationIntegrationEventHandler>();
        //eventBus.AddSubscription<ProductStatusChangedToPaidIntegrationEvent, ProductStatusChangedToPaidIntegrationEventHandler>();
    }
}
