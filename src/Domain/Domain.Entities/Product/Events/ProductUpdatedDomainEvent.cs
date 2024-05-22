using Domain.Infrastructure;

namespace Domain.Entities.Product.Events;

public record ProductUpdatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductUpdatedDomainEvent(Product product)
    {
        Product = product;
    }
}
