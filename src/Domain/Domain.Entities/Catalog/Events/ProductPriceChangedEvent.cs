namespace Domain.Entities.Catalog.Events;
public record ProductPriceChangedEvent(Product Product, decimal OldPrice, decimal NewPrice) : BaseEvent;
