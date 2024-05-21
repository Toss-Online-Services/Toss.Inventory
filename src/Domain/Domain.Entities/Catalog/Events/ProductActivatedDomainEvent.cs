using Domain.Entities.Catalog;
using Domain.Infrastructure;

namespace Domain.Entities.Catalog.Events;

public record ProductActivatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductActivatedDomainEvent(Product product)
    {
        Product = product;
    }
}
