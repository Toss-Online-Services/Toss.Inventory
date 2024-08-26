namespace Domain.Entities.Events;
public record class ProductPriceChangedDomainEvent(Product product, decimal OldPrice, decimal NewPrice) : BaseEvent;
