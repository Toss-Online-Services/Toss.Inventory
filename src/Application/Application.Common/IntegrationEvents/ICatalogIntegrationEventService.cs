namespace Application.Infrastructure.IntegrationEvents;

public interface ICatalogIntegrationEventService
{
    Task PublishEventsThroughEventBusAsync(IntegrationEvent evt);
    Task PublishEventsThroughEventBusAsync(Guid transactionId);
    Task AddAndSaveEventAsync(IntegrationEvent evt);
}
