using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;
public record ProductPriceChangedEvent(Product Product, decimal OldPrice, decimal NewPrice) : BaseEvent;
