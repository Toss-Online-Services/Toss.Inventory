namespace Application.Events.IntegrationEvents.Events;

public record ConfirmedOrderStockItem(int ProductId, bool HasStock);
