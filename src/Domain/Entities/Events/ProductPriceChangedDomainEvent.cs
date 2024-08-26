namespace Toss.Inventory.Domain.Entities.Events;
using Catalog;
using Toss.Inventory.Domain.Entities;

public record class ProductPriceChangedDomainEvent(Product product, decimal OldPrice, decimal NewPrice) : BaseEvent;
