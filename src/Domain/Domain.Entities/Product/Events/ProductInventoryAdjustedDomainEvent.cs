
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductInventoryAdjustedDomainEvent(Product product, int OldQuantity, int NewQuantity) : BaseEvent;
