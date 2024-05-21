using Infrastructure.EventBus.Events;

namespace Application.Infrastructure.IntegrationEvents.Events;

public record OrderStockConfirmedIntegrationEvent(int OrderId) : IntegrationEvent;
