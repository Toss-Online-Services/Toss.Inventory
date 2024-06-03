namespace Application.Events.IntegrationEvents;

public interface ICatalogIntegrationEventService
{
    Task AddAndSaveEventAsync(IntegrationEvent evt);
    Task PublishThroughEventBusAsync(IntegrationEvent evt);
    Task PublishThroughEventBusAsync(Guid transactionId);
}
