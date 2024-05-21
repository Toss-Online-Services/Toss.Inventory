using Domain.Entities.Catalog;
using Domain.Infrastructure;

namespace Domain.Entities.Catalog.Events;

public record ProductUpdatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductUpdatedDomainEvent(Product product)
    {
        Product = product;
    }
}
