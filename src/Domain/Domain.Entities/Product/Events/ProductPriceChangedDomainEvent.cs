
using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record class ProductPriceChangedDomainEvent(Product product, decimal OldPrice, decimal NewPrice) : BaseEvent;
