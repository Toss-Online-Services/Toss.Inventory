namespace Application.Events.IntegrationEvents.Events;

public record OrderStatusChangedToAwaitingValidationIntegrationEvent(int OrderId, IEnumerable<OrderStockItem> OrderStockItems) : IntegrationEvent;
