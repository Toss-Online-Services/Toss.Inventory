using Infrastructure.EventBus.Events;

namespace Application.IntegrationEvents;

public interface ICatalogIntegrationEventService
{
    Task PublishEventsThroughEventBusAsync(Guid transactionId);
    Task AddAndSaveEventAsync(IntegrationEvent evt);

    Task PublishThroughEventBusAsync(IntegrationEvent evt);
}
