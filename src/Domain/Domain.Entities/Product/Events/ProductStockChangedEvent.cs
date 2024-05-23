using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record ProductStockChangedEvent(Product Product, int OldPrice, int NewStockQuantity) : BaseEvent;
