namespace Domain.Entities.Catalog.Events;
public record ProductStockChangedEvent(Product Product, int OldPrice, int NewStockQuantity) : BaseEvent;
