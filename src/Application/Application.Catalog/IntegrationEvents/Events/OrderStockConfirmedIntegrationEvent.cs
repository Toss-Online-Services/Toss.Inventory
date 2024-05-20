using Infrastructure.EventBus.Events;

namespace Application.Catalog.IntegrationEvents.Events;

public record OrderStockConfirmedIntegrationEvent(int OrderId) : IntegrationEvent;
