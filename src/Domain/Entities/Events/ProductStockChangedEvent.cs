namespace Toss.Inventory.Domain.Entities.Events;
public record ProductStockChangedEvent(Product Product, int OldPrice, int NewStockQuantity) : BaseEvent;
