namespace Application.Infrastructure.IntegrationEvents.Events;

public record ConfirmedOrderStockItem(int ProductId, bool HasStock);
