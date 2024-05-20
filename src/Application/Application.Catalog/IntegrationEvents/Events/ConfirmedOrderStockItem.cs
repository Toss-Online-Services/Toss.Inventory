namespace Application.Catalog.IntegrationEvents.Events;

public record ConfirmedOrderStockItem(int ProductId, bool HasStock);
