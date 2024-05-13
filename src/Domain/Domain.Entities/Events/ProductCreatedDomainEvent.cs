using Domain.Entities.Catalog;

namespace Domain.Entities.Events;

public class ProductCreatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductCreatedDomainEvent(Product product)
    {
        Product = product;
    }
}
