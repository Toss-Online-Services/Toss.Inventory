namespace Domain.Entities.Catalog.Events;
using Catalog;
public record class ProductPriceChangedDomainEvent(Product product, decimal OldPrice, decimal NewPrice) : BaseEvent;
