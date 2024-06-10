namespace Domain.Entities.Catalog.Events;

public record class ProductStockQuantityChangedDomainEvent(Product product, int OldQuantity, int NewQuantity) : BaseEvent;
