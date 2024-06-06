namespace Domain.Entities.Product.Events;

public record class ProductStockQuantityChangedDomainEvent(Product product, int OldQuantity, int NewQuantity) : BaseEvent;
