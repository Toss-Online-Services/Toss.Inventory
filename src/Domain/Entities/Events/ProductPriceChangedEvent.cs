namespace Domain.Entities.Events;
public record ProductPriceChangedEvent(Product Product, decimal OldPrice, decimal NewPrice) : BaseEvent;
