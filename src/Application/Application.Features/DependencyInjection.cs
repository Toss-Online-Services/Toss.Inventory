using System.Reflection;
using Application.Events.IntegrationEvents.EventHandling;
using Application.Events.IntegrationEvents.Events;
using Application.Infrastructure.Behaviours;
using Infrastructure.EventBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.EventBus.Extensions;
using Microsoft.Extensions.Hosting;
using Application.Events.IntegrationEvents;
using Application.Infrastructure.Interfaces;
using Domain.Infrastructure;
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
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        builder.AddRabbitMqEventBus("eventbus")
           .AddEventBusSubscriptions();

        services.AddTransient<IIdentityService, IdentityService>();


        return services;
    }
    private static void AddEventBusSubscriptions(this IEventBusBuilder eventBus)
    {
        eventBus.AddSubscription<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
        eventBus.AddSubscription<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();
    }
}
