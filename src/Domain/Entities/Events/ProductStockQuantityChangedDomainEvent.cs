namespace Toss.Inventory.Domain.Entities.Events;

public record class ProductStockQuantityChangedDomainEvent(Product product, int OldQuantity, int NewQuantity) : BaseEvent;
