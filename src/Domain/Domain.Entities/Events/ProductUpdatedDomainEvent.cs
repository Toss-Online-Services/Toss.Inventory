using Domain.Entities.Catalog;

namespace Domain.Entities.Events;

public class ProductUpdatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductUpdatedDomainEvent(Product product)
    {
        Product = product;
    }
}
